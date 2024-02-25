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
        TeamInputDto teamInput;
        TeamPredictionOutput prediction;
        try
        { 
            teamInput = JsonConvert.DeserializeObject<TeamInputDto>(input.GetRawText());
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }

        //DB Requisition to get the team obj
        
        string firstTeamName = "ABCD";
        string secondTeamName = "EFGH";
        prediction = _predictorClient.TeamPrediction(new TeamInput { FirstTeamAcronym = firstTeamName, SecondTeamAcronym = secondTeamName });
        
        _logger.LogDebug("Team prediction: {} x {}", teamInput.FirstTeamId, teamInput.SecondTeamId);
        return teamInput.FirstTeamId;
    }
}