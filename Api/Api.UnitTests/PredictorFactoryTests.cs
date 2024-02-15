namespace Api.UnitTests;

public class Fixture
{
    public IPredictorFactory Factory { get; set; }

    public Fixture()
    {
        Mock<ILogger<Predictor>> logger = new();
        Factory = new PredictorFactory(logger.Object);
    }
    public void Dispose() { }
}

public class PredictorFactoryTests : IClassFixture<Fixture>
{
    private readonly IPredictorFactory _factory;

    public PredictorFactoryTests(Fixture fixture)
    {
        _factory = fixture.Factory;
    }

    [Fact]
    public void CreatePredictor_ChampionshipType_ReturnsChampionshipPredictor()
    {
        // Setup
        Predictor predictor = _factory.Create(PredictionTypes.Championships);
        
        // Assert
        Assert.Equal(typeof(ChampionshipPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_TeamsType_ReturnsChampionshipPredictor()
    {
        // Setup
        Predictor predictor = _factory.Create(PredictionTypes.Teams);
        
        // Assert
        Assert.Equal(typeof(TeamPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_PlayerType_ReturnsChampionshipPredictor()
    {
        // Setup
        Predictor predictor = _factory.Create(PredictionTypes.Players);
        
        // Assert
        Assert.Equal(typeof(PlayerPredictor), predictor.GetType());
    }
    
    [Fact]
    public void CreatePredictor_UnexpectedPredictionType_ThrowsException()
    {
        // Setup
        const int unexpectedType = int.MaxValue;
        // Assert
        Assert.Throws<PredictionTypeNotFoundException>(() => _factory.Create((PredictionTypes) unexpectedType));
    }
}