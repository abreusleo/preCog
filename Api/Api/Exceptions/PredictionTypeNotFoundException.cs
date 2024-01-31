using System.Net;

namespace Api.Exceptions;

public class PredictionTypeNotFoundException : BasePrecogException
{
    private new const string Message = "Prediction type not found.";
    private new const string Identifier = "PredictionTypeNotFoundException";
    private new const HttpStatusCode StatusCode = HttpStatusCode.NotFound;

    public PredictionTypeNotFoundException() : base(Message, StatusCode, Identifier) 
    {
    }
}