using System.Text;

namespace ProfileParser.Utils;

public class InputHandler
{
    public string HandlePasswordInput()
    {
        Console.Clear();
        var password = new StringBuilder();
        var stars = new StringBuilder();
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            password.Append(key);

            if (key.Key != ConsoleKey.Enter)
            {
                stars.Append("*");
                Console.Clear();
                Console.Write(stars.ToString());
            }

        } while (key.Key != ConsoleKey.Enter);

        return password .ToString();
    }
}