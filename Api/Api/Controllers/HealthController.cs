using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    public HealthController() { }

    [HttpGet]
    public IActionResult HealthCheck()
    {
        return Ok(200);
    }
}