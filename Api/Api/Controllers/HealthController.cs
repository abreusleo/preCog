using System.Collections.Generic;
using Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    public HealthController() { }
 
    [HttpGet]
    [SwaggerOperation(Summary = "Check if the application is healthy.", Description = "Check if the application is healthy.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public IActionResult HealthCheck()
    {
        return Ok("Application is healthy.");
    }
}