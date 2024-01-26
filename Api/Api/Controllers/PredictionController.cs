using System;
using System.Collections.Generic;
using Api.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
using Api.Dtos;
using Enum = System.Enum;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PredictionController : ControllerBase
{
    private readonly ILogger<PredictionController> _logger;
    private readonly Predictor.PredictorClient _predictorClient;

    public PredictionController(ILogger<PredictionController> logger, Predictor.PredictorClient predictorClient)
    {
        _logger = logger;
        _predictorClient = predictorClient;
    }
    
    [HttpGet("Types")]
    public IActionResult GetTypes()
    {
        IEnumerable<string> types = Enum.GetNames(typeof(PredictionTypes));
        return Ok(types);
    }
    
    [HttpPost]
    [Route("GRPC")]
    public IActionResult Predict([FromQuery]PredictionTypes type, [FromBody]JsonElement input)
    {
        PredictionOutput prediction;
        //TODO: Think about using a Factory to predict the result
        switch (type)
        {
            case PredictionTypes.Players:
                var playerInput = input.Deserialize<PlayerInput>();
                _logger.LogTrace("Player prediction: {} x {}", playerInput.FirstPlayerId, playerInput.SecondPlayerId);
                prediction = _predictorClient.PlayerPrediction(new PlayerInput { FirstPlayerId = playerInput.FirstPlayerId, SecondPlayerId = playerInput.SecondPlayerId });
                return Ok(prediction.Id);

            case PredictionTypes.Teams:
                var teamInput = input.Deserialize<TeamInput>();
                _logger.LogTrace("Team prediction: {} x {}", teamInput.FirstTeamId, teamInput.SecondTeamId);
                prediction = _predictorClient.TeamPrediction(new TeamInput { FirstTeamId = teamInput.FirstTeamId, SecondTeamId = teamInput.SecondTeamId });
                return Ok(prediction.Id);
            
            case PredictionTypes.Championships:
                var championshipInput = input.Deserialize<ChampionshipInput>();
                _logger.LogTrace("Championship prediction: {}", championshipInput.Id);
                prediction = _predictorClient.ChampionshipPrediction(new ChampionshipInput { Id = championshipInput.Id });
                return Ok(prediction.Id);
            
            default:
                return NotFound();
        }
    }
}
