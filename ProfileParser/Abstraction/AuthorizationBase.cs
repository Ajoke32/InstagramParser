using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProfileParser.Interfaces;
using ProfileParser.Options;

namespace ProfileParser.Abstraction;

public abstract class AuthorizationBase : IAuthorization
{
    public AuthorizationOptions Options { get; private set; }
    
    public  ChromeDriver Driver { get; private set; }

    public AuthorizationBase(AuthorizationOptions opt, ChromeDriver driver)
    {
        Options = opt;
        Driver = driver;
    }

    public void Refresh()
    {
        Driver.Navigate().Refresh();
    }

    public abstract bool Authorize(string login, string password);
    public void UseAuthorizationOptions(Action<AuthorizationOptions> optionsFunc)
    {
        optionsFunc(Options);
    }
}