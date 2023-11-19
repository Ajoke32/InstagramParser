using ProfileParser.Data;
using ProfileParser.Interfaces;
using ProfileParser.Interfaces.Parsers;


namespace ProfileParser.Parsers;

public class InstagramParserTemplate:IParserTemplate
{
    private readonly InstagramParser _parser;
    
    public InstagramParserTemplate(InstagramParser parser)
    {
        _parser = parser;
    }
    public Task ParseAsync()
    {
        return Task.Run(() =>
        {
            try
            {
                _parser.HideNotificationModal();

                _parser.MoveToAccount();
                
                _parser.InitFollowersBLock();

                _parser.ParseFollowers();

                _parser.ParseAccounts();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...");
            }
        });
    }

    public async Task SaveAsync(ISaveDataStrategy dataSaver)
    {
        await dataSaver.SaveAsync(_parser.Users);
    }


    public async Task ExecuteTemplateAsync()
    {
        await ParseAsync();
        await SaveAsync(new JsonSaveData());
    }
}