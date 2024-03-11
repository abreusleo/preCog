using System;
using Api.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public HealthController(IUnitOfWork uow)
    {
        _uow = uow;
    }
 
    [HttpGet]
    [SwaggerOperation(Summary = "Check if the application is healthy.", Description = "Check if the application is healthy.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public IActionResult HealthCheck()
    {
        try
        {
            return Ok(_uow.Connect());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}