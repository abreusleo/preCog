using System;
using System.Net;

namespace Api.Exceptions.Base;

public class BasePrecogException : Exception
{
    public override string Message { get; }
    public HttpStatusCode StatusCode { get; }
    public string Identifier { get; }
    
    protected BasePrecogException(string message, HttpStatusCode statusCode, string identifier)
        : base(message)
    {
        this.Message = message;
        this.StatusCode = statusCode;
        this.Identifier = identifier;
    }
}