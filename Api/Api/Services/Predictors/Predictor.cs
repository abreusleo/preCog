using System.Text.Json;

namespace Api.Services.Predictors;

public abstract class Predictor
{
    public abstract int Predict(JsonElement input);
}