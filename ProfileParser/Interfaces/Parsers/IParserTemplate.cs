namespace ProfileParser.Interfaces.Parsers;

public interface IParserTemplate
{
    public Task ParseAsync();

    public Task SaveAsync(ISaveDataStrategy dataSaver);
    
    public Task ExecuteTemplateAsync();
}