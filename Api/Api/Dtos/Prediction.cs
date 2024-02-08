using System.Text.Json;
using Api.Enums;
using Newtonsoft.Json;

namespace Api.Dtos;

public class Prediction
{
    public PredictionTypes Type { get; set; }
    public JsonElement Input { get; set; }
}

public class TeamInput
{
    [JsonProperty(Required = Required.Always)]
    public int FirstTeamId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public int SecondTeamId { get; set; }
}

public class ChampionshipInput
{
    [JsonProperty(Required = Required.Always)]
    public int Id { get; set; }
}

public class PlayerInput
{
    [JsonProperty(Required = Required.Always)]
    public int FirstPlayerId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public int SecondPlayerId { get; set; }
}
