namespace test.Models
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Experience { get; set; }

        public PlayerCharacter(string name)
        {
            Name = name;
            Health = 100;
            Experience = 0;
        }
    }
}
