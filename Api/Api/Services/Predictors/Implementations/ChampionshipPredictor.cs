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
    public ChampionshipPredictor(ILogger<Predictor> logger)
    {
        _logger = logger;
    }

    public override int Predict(JsonElement input)
    {
        ChampionshipInput championshipInput;
        try
        { 
            championshipInput = JsonConvert.DeserializeObject<ChampionshipInput>(input.GetRawText());
        }
        catch (Exception e)
        {
            throw new InvalidPredictionInputException();
        }
        
        _logger.LogDebug("Championship prediction: {}", championshipInput.Id);
        return championshipInput.Id;
    }
}