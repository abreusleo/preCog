using Api.Enums;
using Api.Exceptions;
using Api.Services.Predictors.Implementations;
using Microsoft.Extensions.Logging;

namespace Api.Services.Predictors;

public interface IPredictorFactory
{
    public Predictor Create(PredictionTypes type);
    public Predictor Create(int type);
}

public class PredictorFactory : IPredictorFactory
{
    private readonly ILogger<Predictor> _logger;
    private readonly PredictorGrpc.PredictorGrpcClient _predictorClient;

    public PredictorFactory(ILogger<Predictor> logger, PredictorGrpc.PredictorGrpcClient predictorClient)
    {
        _logger = logger;
        _predictorClient = predictorClient;
    }

    public Predictor Create(PredictionTypes type)
    {
        return type switch
        {
            PredictionTypes.Championships => new ChampionshipPredictor(_logger, _predictorClient),
            PredictionTypes.Players => new PlayerPredictor(_logger, _predictorClient),
            PredictionTypes.Teams => new TeamPredictor(_logger, _predictorClient),
            _ => throw new PredictionTypeNotFoundException()
        };
    }
    
    public Predictor Create(int type)
    {
        PredictionTypes enumType = (PredictionTypes) type; 
        return enumType switch
        {
            PredictionTypes.Championships => new ChampionshipPredictor(_logger, _predictorClient),
            PredictionTypes.Players => new PlayerPredictor(_logger, _predictorClient),
            PredictionTypes.Teams => new TeamPredictor(_logger,_predictorClient),
            _ => throw new PredictionTypeNotFoundException(type)
        };
    }
}