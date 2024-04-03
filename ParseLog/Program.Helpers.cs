
public partial class Program
{
    /// <summary>
    /// Prints the text in Yellow Color as Warning on Console
    /// </summary>
    /// <param name="text">The message</param>
    public static void Warn(string text)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Warn> {text}");
        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// Prints the text in Green Color as Info on Console
    /// </summary>
    /// <param name="text">The message</param>
    public static void Info(string text)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Info> {text}");
        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// Prints the text in Reed Color as Error on Console
    /// </summary>
    /// <param name="text">The message</param>
    public static void Error(string text)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error> {text}");
        Console.ForegroundColor = previousColor;
    }

}
