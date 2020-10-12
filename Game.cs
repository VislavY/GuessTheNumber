using System;

namespace GuessTheNumber
{
    internal class Game
    {
        private static Game _game;

        public static Game Create()
        {
            _game ??= new Game(); 

            return _game;
        }

        public void Start(Difficulty difficulty)
        {
            Console.Clear();

            var random = new Random();
            int secretNum = random.Next(1, 101);
            Console.WriteLine("Computer thought of a number.");

            int attempts = difficulty switch
            {
                Difficulty.Easy => 7,
                Difficulty.Medium => 5,
                Difficulty.Hard => 3,
                _ => throw new ArgumentOutOfRangeException(),
            };

            while (attempts > 0)
            {
                Console.WriteLine($"Try to guess. You have {attempts} attempts.");

                if (!int.TryParse(Console.ReadLine(), out int userNum))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You entered not a number.");
                    Console.ResetColor();

                    attempts--;

                    continue;
                }

                if (userNum == secretNum)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You win! Secret number: {secretNum}.");
                    Console.ResetColor();

                    return;
                }

                if (userNum < secretNum)
                {
                    Console.WriteLine("Your number < secter number.");
                }
                else
                {
                    Console.WriteLine("Your number > secter number.");
                }

                attempts--;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You lose! Secret number: {secretNum}.");
            Console.ResetColor();
        }
    }
}
