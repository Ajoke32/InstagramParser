using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Options;

namespace ProfileParser.Authorization;

public class ProfileAuthorization:AuthorizationBase
{
    
    public ProfileAuthorization(AuthorizationOptions opt,ChromeDriver driver) : base(opt,driver) { }

    public void Do()
    {
        
    }
}

