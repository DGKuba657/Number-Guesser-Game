namespace Number_Guesser.Game_Types.Handlers;

public class GameStats {
    public void DisplayStats(int lowerBound, int upperBound, int attempts) {
        Console.WriteLine("Please set the range between numbers you want to guess: ");
        Console.WriteLine($"Im thinking of number between {lowerBound} and {upperBound}.");
        Console.WriteLine($"attempts: {attempts}");
        Console.WriteLine();
    } 
}