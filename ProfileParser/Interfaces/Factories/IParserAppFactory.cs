using ProfileParser.Interfaces.Parsers;
using ProfileParser.Options;

namespace ProfileParser.Interfaces.Factories;

public interface IParserAppFactory
{
    public IParserApp CreateInstance<T>(ApplicationOptions options) where T:IParserApp;
}