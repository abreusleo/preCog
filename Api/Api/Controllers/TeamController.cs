using System.Collections.Generic;
using Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;

    public TeamController(ILogger<TeamController> logger)
    {
        _logger = logger;
    }
        
    [HttpGet]
    [SwaggerOperation(Summary = "Get a list of all teams.", Description = "Get a list of all available teams.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPossibleTeamsDto>))]
    public IActionResult GetPossibleTeams()
    {
        GetPossibleTeamsDto dto = new GetPossibleTeamsDto { Id = 0, Name = "Loud", Acronym = "LOUD", LogoUrl = "https://yt3.googleusercontent.com/hBufrTeLwDxrrZOjMsQEooQrne6pRAhdSFhOivYfq5gywsmpYmmRLK24YaDZKN3AdGNvX0Z0=s900-c-k-c0x00ffffff-no-rj"};
        GetPossibleTeamsDto secondDto = new GetPossibleTeamsDto { Id = 1, Name = "NRG", Acronym = "NRG", LogoUrl = "https://yt3.googleusercontent.com/6h5O0YcxI5_liolywkyVIgW5ZC9hrcWe42vMDqBkEbZrLrsdif3kvAUj04_GQiswh4zqFKsf=s900-c-k-c0x00ffffff-no-rj"};
        
        List<GetPossibleTeamsDto> dtoList = new List<GetPossibleTeamsDto>{ dto, secondDto };
        return Ok(dtoList);
    }
}