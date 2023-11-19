using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Options;

namespace ProfileParser.Factories;

public interface IParserAppFactory
{
    public IParserApp CreateInstance<T>(ApplicationOptions options) where T:IParserApp;
}