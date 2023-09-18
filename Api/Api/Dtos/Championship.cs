using Api.Enums;

namespace Api.Dtos;

public class GetPossibleChampionshipsDto
{
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Region { get; set; }
}