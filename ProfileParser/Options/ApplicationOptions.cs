using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Factories;

namespace ProfileParser.Options;

public class ApplicationOptions
{
    private readonly IProfileParserFactory _profileFactory;

    private readonly IAuthorizationFactory _authFactory;
    
    public ApplicationOptions(IProfileParserFactory profileFactory,IAuthorizationFactory authFactory)
    {
        _profileFactory = profileFactory;
        _authFactory = authFactory;
    }

    private IAuthorization _authorization;

    private IProfileParser _profileParser;

    public ChromeDriver Driver { get; set; }

    public AuthorizationOptions AuthorizationOptions { get; set; }

    public ProfileParsingOptions ProfileParsingOptions { get; set; }

    public void UseAuthorization<T>() where T:IAuthorization
    {
        _authorization = _authFactory.CreateAuthorization<T>();
    }

    public void UseProfileParser<T>() where T:IProfileParser
    {
        _profileParser = _profileFactory.CreateProfileParser<T>();
    }
}