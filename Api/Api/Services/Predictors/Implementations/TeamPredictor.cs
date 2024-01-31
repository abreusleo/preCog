using System;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Api.Predictors;
using Microsoft.Extensions.Logging;

namespace Api.Services.Predictors.Implementations;

public class TeamPredictor : Predictor
{
    private readonly ILogger<Predictor> _logger;
    public TeamPredictor(ILogger<Predictor> logger)
    {
        _logger = logger;
    }
    
    public override int Predict(JsonElement input)
    {
        TeamInput teamInput;
        try
        { 
            teamInput = input.Deserialize<TeamInput>();
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }
        
        _logger.LogDebug("Team prediction: {} x {}", teamInput.FirstTeamId, teamInput.SecondTeamId);
        return teamInput.FirstTeamId;
    }
}