using System.Net;
using Api.Exceptions.Base;

namespace Api.Exceptions;

public class InvalidPredictionInputException : BasePrecogException
{
    private new const string Message = "Invalid prediction input.";
    private new const string Identifier = "InvalidPredictionInputException";
    private new const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

    public InvalidPredictionInputException() : base(Message, StatusCode, Identifier) 
    {
    }
}