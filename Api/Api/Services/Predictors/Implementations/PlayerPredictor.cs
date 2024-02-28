using System;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Services.Predictors.Implementations;

public class PlayerPredictor : Predictor
{
    private readonly ILogger<Predictor> _logger;
    private readonly PredictorGrpc.PredictorGrpcClient _predictorClient;
    public PlayerPredictor(ILogger<Predictor> logger, PredictorGrpc.PredictorGrpcClient predictorClient)
    {
        _logger = logger;
        _predictorClient = predictorClient;
    }
    
    public override int Predict(JsonElement input)
    {
        PlayerInputDto playerInput;
        PlayerPredictionOutput prediction;
        try
        { 
            playerInput = JsonConvert.DeserializeObject<PlayerInputDto>(input.GetRawText());
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }

        //DB Requisition to get the player obj

        string firstPlayerNickname = "bruninhobrabo";
        string firstPlayerTeam = "ABCD";

        string secondPlayerNickname = "carlosboladao";
        string secondPlayerTeam = "EFGH";

        prediction = _predictorClient.PlayerPrediction(new PlayerInput { 
            FirstPlayer = new PlayerObj { Nickname = firstPlayerNickname, Team = firstPlayerTeam }, 
            SecondPlayer = new PlayerObj { Nickname = secondPlayerNickname, Team = secondPlayerTeam } 
        });
        
        _logger.LogDebug("Player prediction: {} x {}", playerInput.FirstPlayerId, playerInput.SecondPlayerId);
        return playerInput.FirstPlayerId;
    }
}