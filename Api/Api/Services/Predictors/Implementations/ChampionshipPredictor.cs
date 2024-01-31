using System;
using System.Text.Json;
using Api.Dtos;
using Api.Exceptions;
using Api.Predictors;
using Microsoft.Extensions.Logging;

namespace Api.Services.Predictors.Implementations;

public class ChampionshipPredictor : Predictor
{
    private readonly ILogger<Predictor> _logger;
    public ChampionshipPredictor(ILogger<Predictor> logger)
    {
        _logger = logger;
    }

    public override int Predict(JsonElement input)
    {
        ChampionshipInput championshipInput;
        try
        { 
            championshipInput = input.Deserialize<ChampionshipInput>();
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }
        
        _logger.LogDebug("Championship prediction: {}", championshipInput.Id);
        return championshipInput.Id;
    }
}