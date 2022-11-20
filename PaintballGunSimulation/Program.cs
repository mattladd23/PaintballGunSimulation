using System;

namespace PaintballGun
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use ReadInt method to to get two integer values
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");

            
            Console.Write($"Loaded [false]: ");

            // If TryParse can't parse line, will leave isLoaded as default value
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            // Instantiate paintball gun class
            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

            // Keep looping until needs reloading (when set to false)
            while (true)
            {
                // Display number of balls left to user
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded.");

                // Display empty warning message if no balls loaded
                if (gun.IsEmpty())
                    Console.WriteLine("WARNING: You're out of ammo!");

                // Prompt user by displaying options
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit...");

                // Read user input by assigning key variable
                char key = Console.ReadKey(true).KeyChar;

                // Conditional logic depending on user input
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;
            }

            // Method to prompt user for integer values. Gets arguments for constructor.
            static int ReadInt(int lastUsedValue, string prompt)
            {
                Console.Write(prompt + " [" + lastUsedValue + "]: ");

                string line = Console.ReadLine();

                if (int.TryParse(line, out int value))
                {
                    Console.WriteLine(" using value " + value);
                    return value;
                }
                else
                {
                    Console.WriteLine(" using default value " + lastUsedValue);
                    return lastUsedValue;
                }
            }
        }
    }    
}