using System;

namespace GuessTheNumber
{
    internal static class Program
    {
        private static Difficulty _difficulty = Difficulty.Easy;

        private static void Main()
        {
            Console.Title = "Guess The Number";

            var game = Game.Create();

            while (true)
            {
                Console.Clear();

                string logo =
                    $@"/---\ ----- \  | {Environment.NewLine}" +
                    $@"|       |   |\ | {Environment.NewLine}" +
                    $@"|  -|   |   | \| {Environment.NewLine}" +
                    $@"\---/   |   |  \ {Environment.NewLine}";
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(logo);
                Console.ResetColor();

                string sections =
                    $"[1] Start          {Environment.NewLine}" +
                    $"[2] Set difficulty {Environment.NewLine}" +
                    $"[0] Exit           {Environment.NewLine}";
                Console.WriteLine(sections);

                Console.WriteLine("Select and Enter section number.");
                string sectionNum = Console.ReadLine();

                switch (sectionNum)
                {
                    case "0":
                        return;
                    case "1":
                        game.Start(_difficulty);

                        break;
                    case "2":
                        SwitchDifficulty();

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Entered section number not a found.");
                        Console.ResetColor();

                        break;
                }

                Console.ReadKey();
            }
        }

        private static void SwitchDifficulty()
        {
            string difficulties =
                $"[1] {Difficulty.Easy}   {Environment.NewLine}" +
                $"[2] {Difficulty.Medium} {Environment.NewLine}" +
                $"[3] {Difficulty.Hard}   {Environment.NewLine}";
            Console.WriteLine(difficulties);

            Console.WriteLine("Select and Enter difficulty number.");
            string difficultyNum = Console.ReadLine();

            _difficulty = difficultyNum switch
            {
                "1" => Difficulty.Easy,
                "2" => Difficulty.Medium,
                "3" => Difficulty.Hard,
                _ => throw new ArgumentOutOfRangeException(),
            };

            Console.WriteLine($"Difficulty has been changed to {_difficulty}.");
        }
    }
}
