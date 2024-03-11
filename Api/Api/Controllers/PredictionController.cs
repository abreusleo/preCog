using System.Collections.Generic;
using Api.Enums;
using Api.Exceptions.Base;
using Api.Services.Predictors;
using Enum = System.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(Summary = "Get a list of prediction types.", Description = "Get a list of all available prediction types.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
    public IActionResult GetTypes()
    {
        IEnumerable<string> types = Enum.GetNames(typeof(PredictionTypes));
        return Ok(types);
    }
    
    [HttpPost]
    [Route("GRPC")]
    [SwaggerOperation(Summary = "Predicts the outcome of matches, championships, or player performance.", Description = "The input required can differ depending on the type of prediction being made.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public IActionResult Predict([FromQuery]int type, [FromBody]JsonElement input)
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
