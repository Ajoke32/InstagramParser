using ProfileParser.Abstraction.Interfaces;

namespace ProfileParser.Factories;

public interface IProfileParserFactory
{
    public IProfileParser CreateProfileParser<T>() where T : IProfileParser;
}