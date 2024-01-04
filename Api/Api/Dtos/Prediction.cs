using System.Text.Json;
using Api.Enums;

namespace Api.Dtos;

public class Prediction
{
    public PredictionTypes Type { get; set; }
    public JsonElement Input { get; set; }
}

public class TeamInput
{
    public int FirstTeamId { get; set; }
    public int SecondTeamId { get; set; }
}

public class ChampionshipInput
{
    public int Id { get; set; }
}

public class PlayerInput
{
    public int FirstPlayerId { get; set; }
    public int SecondPlayerId { get; set; }
}
