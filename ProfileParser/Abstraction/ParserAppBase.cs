using ProfileParser.Interfaces.Parsers;
using ProfileParser.Options;

namespace ProfileParser.Abstraction;

public abstract class ParserAppBase:IParserApp
{
    public ApplicationOptions ApplicationOptions { get; }
    
    
    public ParserAppBase(ApplicationOptions options)
    {
       ApplicationOptions = options;
    }
    
    public abstract Task StartAsync();
}