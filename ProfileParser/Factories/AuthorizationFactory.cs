using OpenQA.Selenium.Chrome;
using ProfileParser.Interfaces;
using ProfileParser.Interfaces.Factories;
using ProfileParser.Options;

namespace ProfileParser.Factories;

public class AuthorizationFactory:IAuthorizationFactory
{
    public IAuthorization CreateAuthorization<T>(AuthorizationOptions opt,ChromeDriver driver) where T : IAuthorization
    {
        var instance = Activator.CreateInstance(typeof(T),opt,driver);
        if (instance == null)
        {
            throw new Exception("");
        }

        return (T)instance;
    }
}