using OpenQA.Selenium.Chrome;
using ProfileParser.Options;

namespace ProfileParser.Interfaces.Factories;

public interface IAuthorizationFactory
{
    public IAuthorization CreateAuthorization<T>(AuthorizationOptions opt,ChromeDriver driver) where T : IAuthorization;
}