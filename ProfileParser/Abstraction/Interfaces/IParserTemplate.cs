using ProfileParser.Data;

namespace ProfileParser.Abstraction.Interfaces;

public interface IParserTemplate
{
    public Task Parse();

    public Task Save(ISaveDataStrategy dataSaver);
    
    public Task ExecuteTemplate();
}