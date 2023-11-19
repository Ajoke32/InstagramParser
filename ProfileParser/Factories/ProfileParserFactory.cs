using ProfileParser.Abstraction.Interfaces;

namespace ProfileParser.Factories;

public class ProfileParserFactory:IProfileParserFactory
{
    public IProfileParser CreateProfileParser<T>() where T : IProfileParser
    {
        var instance = Activator.CreateInstance(typeof(T));
        if (instance == null)
        {
            throw new Exception("App type is not defined");
        }

        return (T)instance;
    }
}