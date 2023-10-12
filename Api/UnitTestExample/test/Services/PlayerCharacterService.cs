using test.Models;

namespace test.Services
{
    public class PlayerCharacterService
    {
        public PlayerCharacterService() { }

        public PlayerCharacter CreatePlayerCharacter(string name)
        {
            PlayerCharacter playerCharacter = new PlayerCharacter(name);
            return playerCharacter;
        }

        public PlayerCharacter PlayerCharacterReceiveDamage(PlayerCharacter playerCharacter, int damage)
        {
            var playerHealth = playerCharacter.Health;
            playerCharacter.Health = (playerHealth - damage) < 0 ? 0 : (playerHealth - damage);
            return playerCharacter;
        }

        public PlayerCharacter PlayerCharacterGainExperience(PlayerCharacter playerCharacter, int experienceGained)
        {
            playerCharacter.Experience += experienceGained;
            return playerCharacter;
        }

        public PlayerCharacter RenamePlayerCharacter(PlayerCharacter playerCharacter, string newName)
        {
            playerCharacter.Name = newName;
            return playerCharacter;
        }
    }
}
