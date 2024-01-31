using System.Text.Json;

namespace Api.Predictors;

public abstract class Predictor
{
    public abstract int Predict(JsonElement input);
}