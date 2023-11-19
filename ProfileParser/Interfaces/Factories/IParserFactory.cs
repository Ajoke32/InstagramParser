using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Options;
using ProfileParser.Interfaces.Parsers;

namespace ProfileParser.Interfaces.Factories;

public interface IParserFactory
{
    public IParser  CreateProfileParser<T>(ParsingOptions opt, ChromeDriver driver) where T : IParser;
}