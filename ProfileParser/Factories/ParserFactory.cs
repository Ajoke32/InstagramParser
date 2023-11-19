using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Options;
using ProfileParser.Interfaces.Factories;
using ProfileParser.Interfaces.Parsers;

namespace ProfileParser.Factories;

public class ParserFactory:IParserFactory
{
    public IParser CreateProfileParser<T>(ParsingOptions opt, ChromeDriver driver) where T : IParser
    {
        var instance = Activator.CreateInstance(typeof(T),opt,driver);
        if (instance == null)
        {
            throw new Exception("App type is not defined");
        }

        return (T)instance;
    }
}