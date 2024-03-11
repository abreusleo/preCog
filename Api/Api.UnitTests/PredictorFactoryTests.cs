using Api.Enums;
using Api.Services.Predictors;
using Api.Services.Predictors.Implementations;
using Api.Exceptions;

namespace Api.UnitTests;

public class Fixture
{
    public IPredictorFactory Factory { get; set; }

    public Fixture()
    {
        Mock<ILogger<Predictor>> logger = new();
        Mock<PredictorGrpc.PredictorGrpcClient> grpcClient = new();
        Factory = new PredictorFactory(logger.Object, grpcClient.Object);
    }
    public void Dispose() { }
}

public class PredictorFactoryTests : IClassFixture<Fixture>
{
    private readonly IPredictorFactory _predictorFactory;

    public PredictorFactoryTests()
    {
        Fixture fixture = new Fixture();
        _predictorFactory = fixture.Factory;
    }

    [Fact]
    public void CreatePredictor_ChampionshipType_ReturnsChampionshipPredictor()
    {
        // Setup
        Predictor predictor = _predictorFactory.Create(PredictionTypes.Championships);
        
        // Assert
        Assert.Equal(typeof(ChampionshipPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_TeamsType_ReturnsTeamPredictor()
    {
        // Setup
        Predictor predictor = _predictorFactory.Create(PredictionTypes.Teams);
        
        // Assert
        Assert.Equal(typeof(TeamPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_PlayerType_ReturnsPlayerPredictor()
    {
        // Setup
        Predictor predictor = _predictorFactory.Create(PredictionTypes.Players);
        
        // Assert
        Assert.Equal(typeof(PlayerPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_UnexpectedPredictionType_ThrowsException()
    {
        // Setup
        const int unexpectedType = int.MaxValue;
        // Assert
        Assert.Throws<PredictionTypeNotFoundException>(() => _predictorFactory.Create((PredictionTypes) unexpectedType));
    }
}