using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Data;

namespace ProfileParser.Parsers;

public class InstagramParserTemplate
{
    private readonly InstagramParser _parser;
    
    public InstagramParserTemplate(InstagramParser parser)
    {
        _parser = parser;
    }
    public Task Parse()
    {
        return Task.Run(() =>
        {
            try
            {
                _parser.HideNotificationModal();

                _parser.MoveToAccount();

                //_driver.Navigate().GoToUrl("https://www.instagram.com/obezbashena15/");

                _parser.InitFollowersBLock();

                while (_parser.MoveNext())
                {
                    Console.Clear();
                }

                _parser.ParseUsers();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...");
            }
        });
    }

    public Task Save(ISaveDataStrategy dataSaver)
    {
        return Task.Run(() =>
        {
            dataSaver.Save(_parser.Users);
        });
    }


    public async Task ExecuteTemplate()
    {
        await Parse();
        await Save(new JsonSaveData());
    }
}