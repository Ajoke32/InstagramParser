using ProfileParser.Options;

namespace ProfileParser.Abstraction.Interfaces;

public interface IAuthorization
{
    public bool Authorize(string login,string password);

    public void UseAuthorizationOptions(Action<AuthorizationOptions> options);
}