using System.Xml;

namespace Number_Guesser;

class Number_Guesser {
    public static void Main() {
        bool GameRunning = true;
        while (GameRunning) {
            Random rnd = new Random();
            int lowerBound = 0, upperBound = 0;

            Console.WriteLine("Set the Range of Numbers ");
            lowerBound = GetValidNumber("Enter lower bound: ");

            upperBound = GetValidNumber("Enter upper bound: ");
            while (upperBound <= lowerBound) {
                Console.WriteLine("Invalid number. Upper Bound must be greater than lower bound.");
                upperBound = GetValidNumber("Enter upper bound: ");
            }
            int NumberToGuess = rnd.Next(lowerBound, upperBound + 1);
            int Guess = 0;
            int attempts = 0;

            while (Guess != NumberToGuess) {
                Guess = GetValidNumber("Enter number: ");
                attempts++;

                if (Guess > NumberToGuess) {
                    Console.WriteLine("You guessed too high number. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    GameStats(lowerBound, upperBound, attempts);
                }
                else if (Guess < NumberToGuess) {
                    Console.WriteLine("You guessed too low number. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    GameStats(lowerBound, upperBound, attempts);
                }
                else {
                    Console.Clear();
                    Console.WriteLine($"You correctly guessed the number {NumberToGuess} in {attempts} attempts.");
                }
            }
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Do you want to continue? (y/n)");
            string input = Console.ReadLine();
            
            if (input.ToLower() is "n" or "no" or "nah" or "ne") {
                GameRunning = false;
                Console.Clear();
            }
            else {
                Console.Clear();
            }
        }
       
    }


    public static int GetValidNumber(string prompt){
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number)) {
            Console.WriteLine("Invalid input.");
            Console.Write(prompt);
        }
        return number;
    }

    public static void GameStats(int lowerBound, int upperBound, int attempts) {
        Console.WriteLine("Please set the range between numbers you want to guess: ");
        Console.WriteLine($"Im thinking of number between {lowerBound} and {upperBound}.");
        Console.WriteLine($"attempts: {attempts}");
        Console.WriteLine();
    }
}