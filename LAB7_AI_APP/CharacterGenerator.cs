using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_AI_APP
{
    
    public class Character
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Health { get; set; }
        public string SpecialAbility { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nStrength: {Strength}\nAgility: {Agility}\nHealth: {Health}\nSpecial Ability: {SpecialAbility}");
        }
    }

    // Redundant to create a CharacterGenerator class this falls within "Character", I did not turn this into a static class because of the use of random
    public class CharacterGenerator
    {
        private Random random = new Random();
        private List<string> names = new List<string>
        {
            "Zara", "Thorn", "Luna", "Brax", "Kael", "Nova", "Riven", "Eira", "Drake", "Mira"
        };
        private List<string> abilities = new List<string>
            {
                "Fireball",
                "Invisibility",
                "Teleportation",
                "Healing Touch",
                "Lightning Strike",
                "Time Freeze",
                "Mind Control",
                "Super Speed",
                "Stone Skin",
                "Water Bending",
                "Shape Shifting",
                "Energy Blast",
                "Flight",
                "Shadow Walk",
                "Earthquake Slam",
                "Poison Cloud",
                "Magnetic Pulse",
                "Barrier Shield",
                "Animal Communication",
                "Frost Breath"
            };

        // Generates a random character using random and returns it
        public Character GenerateRandomCharacter() 
        {
            string name = GenerateRandomName();
            int strength = random.Next(1, 100);
            int agility = random.Next(1, 100);
            int health = random.Next(100, 200);
            string ability = GenerateRandomAbility();
            return new Character { Name = name, Strength = strength, Agility = agility, Health = health, SpecialAbility = ability };
        }

        // Function for generating a random name
        private string GenerateRandomName()
        {
            return names[random.Next(names.Count)]; // Returns a random index inside a list of strings
        }

        // Function for generating a random name
        private string GenerateRandomAbility()
        {
            return abilities[random.Next(abilities.Count)]; // Returns a random index inside a list of strings
        }
    }
}
