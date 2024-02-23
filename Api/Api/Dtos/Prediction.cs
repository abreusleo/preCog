using System.Text.Json;
using Api.Enums;
using Newtonsoft.Json;

namespace Api.Dtos;

public class PredictionDto
{
    public PredictionTypes Type { get; set; }
    public JsonElement Input { get; set; }
}

public class TeamInputDto
{
    [JsonProperty(Required = Required.Always)]
    public int FirstTeamId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public int SecondTeamId { get; set; }
}

public class ChampionshipInputDto
{
    [JsonProperty(Required = Required.Always)]
    public int Id { get; set; }
}

public class PlayerInputDto
{
    [JsonProperty(Required = Required.Always)]
    public int FirstPlayerId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public int SecondPlayerId { get; set; }
}
