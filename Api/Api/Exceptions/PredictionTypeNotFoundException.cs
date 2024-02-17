using System.Net;
using Api.Exceptions.Base;

namespace Api.Exceptions;

public class PredictionTypeNotFoundException : BasePrecogException
{
    private const string Message = "Prediction type not found.";
    private new const string Identifier = "PredictionTypeNotFoundException";
    private new const HttpStatusCode StatusCode = HttpStatusCode.NotFound;

    public PredictionTypeNotFoundException() : base(Message, StatusCode, Identifier) 
    {
    }
    
    public PredictionTypeNotFoundException(int predictionType)
        : base($"Prediction type {predictionType} not found.", StatusCode, Identifier)
    {
    }
}