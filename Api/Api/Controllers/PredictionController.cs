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

    public PredictionController(ILogger<PredictionController> logger)
    {
        _logger = logger;
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
        //TODO: Think about using a Factory to predict the result
        
        var winner = "";
        switch (type)
        {
            case PredictionTypes.Teams:
                var teamInput = input.Deserialize<TeamInput>();
                _logger.LogTrace("Team prediction: {} x {}", teamInput.FirstTeam, teamInput.SecondTeam);
                winner = teamInput.FirstTeam;
                break;
            
            case PredictionTypes.Players:
                var playerInput = input.Deserialize<PlayerInput>();
                _logger.LogTrace("Player prediction: {}", playerInput.Name);
                winner = playerInput.Name;
                break;
            
            case PredictionTypes.Championships:
                var championshipInput = input.Deserialize<ChampionshipInput>();
                _logger.LogTrace("Championship prediction: {}", championshipInput.Name);
                winner = championshipInput.Name;
                break;
        }
        return Ok(winner);
    }
}
