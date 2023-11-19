using ProfileParser.Abstraction.Interfaces;

namespace ProfileParser.Factories;

public interface IAuthorizationFactory
{
    public IAuthorization CreateAuthorization<T>() where T : IAuthorization;
}