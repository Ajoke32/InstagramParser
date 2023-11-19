using System.Text;

namespace ProfileParser.Utils;

public class InputHandler
{

    
    public static string HandlePasswordInput()
    {
        var password = new StringBuilder();
        var stars= new StringBuilder();
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            password.Append(key.KeyChar);
            
            if (key.Key == ConsoleKey.Backspace)
            {
                if (stars.Length > 0)
                {
                    stars.Remove(stars.Length - 1, 1);
                    ClearCurrentConsoleLine();
                    Console.Write(stars.ToString());
                }
                continue;
            }
            
            if (key.Key == ConsoleKey.Enter&&string.IsNullOrEmpty(password.ToString()))
            {
                continue;
            }
            ClearCurrentConsoleLine();
            if (key.Key != ConsoleKey.Enter)
            {
                stars.Append("*");
            }

            Console.Write(stars.ToString());

        } while (key.Key != ConsoleKey.Enter);
        
        return password.ToString();
    }
    

    public static string HandleLoginInput()
    {
        var res = Console.ReadLine();

        return res??"error";
    }
    private static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}