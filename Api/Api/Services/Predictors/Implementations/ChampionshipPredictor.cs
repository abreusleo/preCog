using System;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Services.Predictors.Implementations;

public class ChampionshipPredictor : Predictor
{
    private readonly ILogger<Predictor> _logger;
    private readonly PredictorGrpc.PredictorGrpcClient _predictorClient;
    public ChampionshipPredictor(ILogger<Predictor> logger, PredictorGrpc.PredictorGrpcClient predictorClient)
    {
        _logger = logger;
        _predictorClient = predictorClient;
    }

    public override int Predict(JsonElement input)
    {
        ChampionshipInputDto championshipInput;
        ChampionshipPredictionOutput prediction;
        try
        { 
            championshipInput = JsonConvert.DeserializeObject<ChampionshipInputDto>(input.GetRawText());
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }

        //DB Requisition to get the championship obj

        string championshipName = "campeonatinho";

        prediction = _predictorClient.ChampionshipPrediction(new ChampionshipInput { Name = championshipName });
        
        _logger.LogDebug("Championship prediction: {}", championshipInput.Id);
        return championshipInput.Id; //change to a JSON format return
    }
}