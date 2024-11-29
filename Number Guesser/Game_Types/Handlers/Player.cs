namespace Number_Guesser.Game_Types.Handlers;

public class Player {
    public int GetValidNumber(string prompt) {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number)) {
            Console.WriteLine("Invalid input.");
            Console.Write(prompt);
        } 
        return number;
    }
}