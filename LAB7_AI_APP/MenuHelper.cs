using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7_AI_APP
{
    public static class MenuHelper
    {
        // Initiate the list of generated characters
        public static List<Character> generatedCharacters { get; set; } = new List<Character>(); 
        // Create a list of menu choices for the menu that are accounted for in the program, make changes as you like
        private static string[] menuChoices = { "Generate new character", "List all characters", "Exit" }; 
        public static void StartMenu()
        {
            bool running = true;
            while (running) // Endless loop until the user exit
            {
                Console.Clear();
                Console.WriteLine("=== Character Generator ===");
                
                // Loop that prints out i amount of lines depending on how many strings are in menuChoices
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine($"[{i}]: {menuChoices[i]}");
                }

                Console.Write("\nEnter your choice: ");
                int menuIndex = CheckInput(Console.ReadLine(), menuChoices.Length);

                switch (menuIndex) // Input handler, checks which index was chosen, currently only handles 0 - 2
                {
                    // Generate a new character
                    case 0:
                        // Reference the CharacterGenerator class
                        CharacterGenerator generator = new CharacterGenerator();
                        Character newPlayer = generator.GenerateRandomCharacter(); // Reference the 
                        generatedCharacters.Add(newPlayer); // Adds the character to the generatedCharacters list
                        Console.WriteLine("Your character has now been added... rebooting system...");
                        Thread.Sleep(5000); // Wait 5 seconds
                        break;

                    // Check the list of characters
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== Character List ===");

                        // I'll try to turn this into a generic method some day, probably too much of a hassle for now
                        for (int i = 0; i < generatedCharacters.Count; i++)
                        {
                            Console.WriteLine($"[{i}]: {generatedCharacters[i].Name}");
                        }
                        Console.Write("\nEnter the character's stats which you'd like to view: ");

                        // Asks the user for input and sends it, also sends the amount of menu options
                        menuIndex = CheckInput(Console.ReadLine(), generatedCharacters.Count);
                        generatedCharacters[menuIndex].DisplayInfo();
                        Console.WriteLine("Your character has now been displayed... rebooting system...");
                        Thread.Sleep(5000); // Wait 5 seconds
                        break;

                    // Exit
                    case 2:
                        Console.WriteLine("\nThe program is now closing... Thank you for using our service...");
                        Thread.Sleep(500);
                        running = false;
                        break;
                }
            }
        }

        public static int CheckInput(string input, int choiceIndex) // choiceindex being the amount of objects inside the list/array.
        {
            bool inputValid = int.TryParse(input, out int userChoice); // Menu Index is declared here
            while (!inputValid || userChoice >= choiceIndex || userChoice < 0) // If it's within bounds of the index provided
            {
                Console.Write($"\rPlease enter a valid number in between 0 - {choiceIndex - 1}: ");
                inputValid = int.TryParse(Console.ReadLine(), out userChoice);
            }
            return userChoice; // Returns an integer
        }
    } 
}
