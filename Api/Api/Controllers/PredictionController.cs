using System.Collections.Generic;
using Api.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Api.Dtos;
using Enum = System.Enum;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PredictionController : ControllerBase
{
    private readonly ILogger<PredictionController> _logger;

    public PredictionController(ILogger<PredictionController> logger)
    {
        _logger = logger;
    }
    
    [Route("/types")]
    [HttpGet]
    public IActionResult GetTypes()
    {
        IEnumerable<string> types = Enum.GetNames(typeof(PredictionTypes));
        return Ok(types);
    }
    
    [Route("/players")]
    [HttpGet]
    public IActionResult GetPossiblePlayers()
    {
        GetPossiblePlayersDto dto = new GetPossiblePlayersDto { Name = "Carlos",  PhotoUrl = "https://images.unsplash.com/photo-1563409236302-8442b5e644df?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8ZHVja3xlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80"};
        GetPossiblePlayersDto secondDto = new GetPossiblePlayersDto { Name = "Bessa", PhotoUrl = "https://s2-techtudo.glbimg.com/eZA3MfymxGYzGBJK0Ig8EY7ETwA=/0x0:1080x995/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_08fbf48bc0524877943fe86e43087e7a/internal_photos/bs/2020/B/l/bRJmJAQiWdlUY2BWM39w/1.-the-rock.jpg"};

        List<GetPossiblePlayersDto> dtoList = new List<GetPossiblePlayersDto>{ dto, secondDto};
        
        return Ok(dtoList);
    }
    
    [Route("/teams")]
    [HttpGet]
    public IActionResult GetPossibleTeams()
    {
        GetPossibleTeamsDto dto = new GetPossibleTeamsDto { Name = "Loud", Acronym = "LOUD", LogoUrl = "https://yt3.googleusercontent.com/hBufrTeLwDxrrZOjMsQEooQrne6pRAhdSFhOivYfq5gywsmpYmmRLK24YaDZKN3AdGNvX0Z0=s900-c-k-c0x00ffffff-no-rj"};
        GetPossibleTeamsDto secondDto = new GetPossibleTeamsDto { Name = "NRG", Acronym = "NRG", LogoUrl = "https://yt3.googleusercontent.com/6h5O0YcxI5_liolywkyVIgW5ZC9hrcWe42vMDqBkEbZrLrsdif3kvAUj04_GQiswh4zqFKsf=s900-c-k-c0x00ffffff-no-rj"};
        
        List<GetPossibleTeamsDto> dtoList = new List<GetPossibleTeamsDto>{ dto, secondDto };
        return Ok(dtoList);
    }
    
    [Route("/championships")]
    [HttpGet]
    public IActionResult GetPossibleChampionships()
    {
        GetPossibleChampionshipsDto dto = new GetPossibleChampionshipsDto { Name = "VCT Americas", Region = ChampionshipRegions.Americas.ToString(), LogoUrl = "https://cdn.thespike.gg/VCT%25202023%2FVCT23-AMERICAS_1678786271315.png" };
        GetPossibleChampionshipsDto secondDto = new GetPossibleChampionshipsDto { Name = "VCT EMEA", Region = ChampionshipRegions.EMEA.ToString(), LogoUrl = "https://cdn.thespike.gg/VCT%25202023%2FVCT23-AMERICAS_1678786271315.png" };
        List<GetPossibleChampionshipsDto> dtoList = new List<GetPossibleChampionshipsDto> { dto, secondDto };
        
        return Ok(dtoList);
    }
}
