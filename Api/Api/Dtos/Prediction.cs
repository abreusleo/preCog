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
    public string FirstTeam { get; set; }
    public string SecondTeam { get; set; }
}

public class ChampionshipInput
{
    public string Name { get; set; }
}

// TODO: Pensar em como vai funcionar essa predição
public class PlayerInput
{
    public string FirstPlayer { get; set; }
    public string SecondPlayer { get; set; }
}
