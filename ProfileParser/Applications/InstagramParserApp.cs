using ProfileParser.Abstraction;
using ProfileParser.Data;
using ProfileParser.Factories;
using ProfileParser.Interfaces.Parsers;
using ProfileParser.Options;
using ProfileParser.Parsers;
using ProfileParser.Utils;

namespace ProfileParser.Applications;

public class InstagramParserApp : ParserAppBase
{
    private readonly IParserTemplate _parserTemplate;

    public InstagramParserApp(ApplicationOptions options) : base(options)
    {
        _parserTemplate = ParserTemplateFactory.CreateTemplate<InstagramParserTemplate>(options.Parser);
    }

    public override async Task StartAsync()
    {
        Console.Clear();
        string? command;
        try
        {
            do
            {
                Menu();
                command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Try again");
                    continue;
                }

                if (command != "1") continue;

                Console.Write("Enter login:");
                var login = InputHandler.HandleLoginInput();
                Console.Write("Enter password:");
                var password = InputHandler.HandlePasswordInput();
                Console.Clear();
                Console.WriteLine("Authorization being processed...");
                var isSuccess = ApplicationOptions.Authorization.Authorize(login, password);

                if (!isSuccess)
                {
                    Console.WriteLine("Authorization error, try again");
                    ApplicationOptions.Authorization.Refresh();
                    continue;
                }

                Console.Clear();
                Console.WriteLine("You are successfully authorized");
                Menu();
                ParseMenu();
                command = Console.ReadLine();

                switch (command)
                {
                    case "3":
                        await _parserTemplate.ParseAsync();
                        break;
                    case "4":
                    {
                        Console.WriteLine("Make sure your screen is clear and you are authorized");
                        Console.Write("Link:");
                        string? link = Console.ReadLine();
                        if (!string.IsNullOrEmpty(link))
                        {
                            ((InstagramParser)ApplicationOptions.Parser).ParseByLink(link);
                        }

                        break;
                    }
                }

                Console.WriteLine("Parsed successfully. Press 's/S' to save data");
                command = Console.ReadLine();
                if (command.ToLower() == "s")
                {
                    await _parserTemplate.SaveAsync(new JsonSaveData());
                }
            } while (command != "q");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured:{e.Message}");
        }

        ApplicationOptions.Close();
    }

    private void Menu()
    {
        Console.WriteLine("----------Instagram Parser-------------");
        Console.WriteLine("1.Log in, 2.Retry, q - exit");
    }

    private void ParseMenu()
    {
        Console.WriteLine("3.Pars my account, 4.Parse account by link");
    }
}