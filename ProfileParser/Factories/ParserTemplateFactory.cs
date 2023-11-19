using ProfileParser.Interfaces.Parsers;

namespace ProfileParser.Factories;

public class ParserTemplateFactory
{
    public static IParserTemplate CreateTemplate<T>(IParser parser) where T:IParserTemplate
    {
        var instance = (T?)Activator.CreateInstance(typeof(T), parser);
        
        if (instance == null)
        {
            throw new Exception("Type not defined");
        }
        return instance;
    }
}