using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProfileParser.Abstraction;
using ProfileParser.Options;

namespace ProfileParser.Authorization;

public class InstagramAuthorization:AuthorizationBase
{
    
    public InstagramAuthorization(AuthorizationOptions opt,ChromeDriver driver) : base(opt,driver) { }
    
    public override bool Authorize(string login, string password)
    {
        try
        {
            
            var loginField = Driver.FindElement(By.CssSelector(Options.LoginFieldIdentifier));
            var passwordField = Driver.FindElement(By.CssSelector(Options.PasswordFieldIdentifier));
            
            var loginButton = Driver.FindElement(By.CssSelector(Options.LoginButton));
            
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            loginButton.Click();
            
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            
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
                var error = Driver.FindElement(By.CssSelector(Options.ErrorSection));
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
}

