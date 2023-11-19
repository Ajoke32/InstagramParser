using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Options;

namespace ProfileParser.Abstraction;

public abstract class AuthorizationBase : IAuthorization
{
    private AuthorizationOptions Options { get; }
    private readonly ChromeDriver _driver;

    public AuthorizationBase(AuthorizationOptions opt, ChromeDriver driver)
    {
        Options = opt;
        _driver = driver;
    }

    public virtual bool Authorize(string login, string password)
    {
        try
        {
            var loginField = _driver.FindElement(By.CssSelector(Options.LoginFieldIdentifier));
            var passwordField = _driver.FindElement(By.CssSelector(Options.PasswordFieldIdentifier));
            
            var loginButton = _driver.FindElement(By.CssSelector(Options.LoginButton));
            
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            loginButton.Click();
            
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            wait.Until(driver =>
            {
                var isError = true;
                var isSuccess = true;
                try
                {
                    driver.FindElement(By.CssSelector(Options.ErrorSection));
                }
                catch (NoSuchElementException e)
                {
                    isError = false;
                }
                
                try
                {
                    driver.FindElement(By.CssSelector(Options.LogInSuccessElement));
                }
                catch (NoSuchElementException e)
                {
                    isSuccess = false;
                }
                
                return isSuccess || isError;
            });

            try
            {
                var error = _driver.FindElement(By.CssSelector(Options.ErrorSection));
                Console.WriteLine(error.Text);
                return false;
            }
            catch (NoSuchElementException e)
            {
                return true;
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Authorization error occured");
            return false;
        }
    }

    public void UseAuthorizationOptions(Action<AuthorizationOptions> optionsFunc)
    {
        optionsFunc(Options);
    }
}