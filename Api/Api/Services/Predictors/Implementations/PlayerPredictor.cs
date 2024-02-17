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
        PlayerInput playerInput;
        PredictionOutput prediction;
        try
        { 
            playerInput = JsonConvert.DeserializeObject<PlayerInput>(input.GetRawText());
            prediction = _predictorClient.PlayerPrediction(new PlayerInput { FirstPlayerId = playerInput.FirstPlayerId, SecondPlayerId = playerInput.SecondPlayerId });
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }
        
        _logger.LogDebug("Player prediction: {} x {}", playerInput.FirstPlayerId, playerInput.SecondPlayerId);
        return playerInput.FirstPlayerId;
    }
}