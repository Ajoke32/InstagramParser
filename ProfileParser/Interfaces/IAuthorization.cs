using ProfileParser.Options;

namespace ProfileParser.Interfaces;

public interface IAuthorization
{
    public bool Authorize(string login,string password);

    public void UseAuthorizationOptions(Action<AuthorizationOptions> options);

    public void Refresh();
}