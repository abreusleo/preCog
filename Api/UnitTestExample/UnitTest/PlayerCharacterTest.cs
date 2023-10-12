using test.Models;
using test.Services;

namespace UnitTest
{
    public class PlayerCharacterTest
    {
        private readonly PlayerCharacterService _playerCharacterService;
        private PlayerCharacter _sut;

        public PlayerCharacterTest() 
        {
            _playerCharacterService = new PlayerCharacterService();
            _sut = _playerCharacterService.CreatePlayerCharacter("Example");
        }

        [Fact]
        public void CreatePlayerCharacter_SimpleString_ReturnsZeroExperienceAndFullHealth()
        {
            PlayerCharacter sut = _playerCharacterService.CreatePlayerCharacter("Example");

            Assert.Equal(0, sut.Experience);
            Assert.Equal(100, sut.Health);
        }

        [Theory]
        [InlineData(70, 30)]
        [InlineData(20, 80)]
        [InlineData(1, 99)]
        [InlineData(0, 100)]
        [InlineData(100, 0)]
        public void PlayerCharacterReceiveDamage_Between0And100_ReturnTheAmountOfHealthLeft(int input, int expected)
        {
            _playerCharacterService.PlayerCharacterReceiveDamage(_sut, input);

            Assert.Equal(expected, _sut.Health);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(200)]
        [InlineData(10000)]
        public void PlayerCharacterReceiveDamage_Above100_ReturnZero(int input)
        {
            _playerCharacterService.PlayerCharacterReceiveDamage(_sut, input);

            Assert.Equal(0, _sut.Health);
        }
    }
}