using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TestController> _logger;
    private readonly Server.ServerClient _serverClient;

    public TestController(ILogger<TestController> logger, Server.ServerClient serverClient)
    {
        _logger = logger;
        _serverClient = serverClient;
    }

    [HttpGet(Name = "GetTestObject")]
    public IEnumerable<TestObject> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new TestObject
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
        
    [HttpGet]
    [Route("GRPC")]
    public ReturnObj Get(string text, int number)
    {
        _logger.LogTrace("API Request. Text: {text}, Number: {Number}", text, number);
        
        ReturnObj returnObj = _serverClient.RecordRoute(new RequestObj { Example = text, NumberExample = number });
        
        _logger.LogTrace("GPRC response arrived. Response: {response}", returnObj.Result);
        return returnObj;
    }
}