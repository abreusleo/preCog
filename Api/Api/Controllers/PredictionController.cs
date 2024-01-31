using System;
using System.Collections.Generic;
using Api.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Api.Predictors;
using Api.Services.Predictors;
using Enum = System.Enum;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PredictionController : ControllerBase
{
    private readonly ILogger<PredictionController> _logger;
    private readonly PredictorFactory _predictorFactory;

    public PredictionController(ILogger<PredictionController> logger, PredictorFactory predictorFactory)
    {
        _logger = logger;
        _predictorFactory = predictorFactory;
    }
    
    [HttpGet("Types")]
    public IActionResult GetTypes()
    {
        IEnumerable<string> types = Enum.GetNames(typeof(PredictionTypes));
        return Ok(types);
    }
    
    [HttpPost]
    public IActionResult Predict([FromQuery]PredictionTypes type, [FromBody]JsonElement input)
    {
        try
        {
            Predictor predictor = _predictorFactory.Create(type);
            return Ok(predictor.Predict(input));
        }
        catch (BasePrecogException e)
        {
            _logger.LogError("Exception caught while trying to predict result. StatusCode: {ExceptionStatusCode}, Message: {ExceptionMessage}", e.Message, e.StatusCode);
            return StatusCode((int) e.StatusCode, e.Message);
        }
    }
}
