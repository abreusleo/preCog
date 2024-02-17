using System;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Services.Predictors.Implementations;

public class TeamPredictor : Predictor
{
    private readonly ILogger<Predictor> _logger;
    private readonly PredictorGrpc.PredictorGrpcClient _predictorClient;
    public TeamPredictor(ILogger<Predictor> logger, PredictorGrpc.PredictorGrpcClient predictorClient)
    {
        _logger = logger;
        _predictorClient = predictorClient;
    }
    
    public override int Predict(JsonElement input)
    {
        TeamInput teamInput;
        PredictionOutput prediction;
        try
        { 
            teamInput = JsonConvert.DeserializeObject<TeamInput>(input.GetRawText());
            prediction = _predictorClient.TeamPrediction(new TeamInput { FirstTeamId = teamInput.FirstTeamId, SecondTeamId = teamInput.SecondTeamId });
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }
        
        _logger.LogDebug("Team prediction: {} x {}", teamInput.FirstTeamId, teamInput.SecondTeamId);
        return teamInput.FirstTeamId;
    }
}