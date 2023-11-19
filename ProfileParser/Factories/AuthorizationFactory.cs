using ProfileParser.Abstraction.Interfaces;

namespace ProfileParser.Factories;

public class AuthorizationFactory:IAuthorizationFactory
{
    public IAuthorization CreateAuthorization<T>() where T : IAuthorization
    {
        var instance = Activator.CreateInstance(typeof(T));
        if (instance == null)
        {
            throw new Exception("");
        }

        return (T)instance;
    }
}