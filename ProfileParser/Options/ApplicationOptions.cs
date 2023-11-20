using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Options;
using ProfileParser.Interfaces;
using ProfileParser.Interfaces.Factories;
using ProfileParser.Interfaces.Parsers;
using ProfileParser.Parsers;

namespace ProfileParser.Options;

public class ApplicationOptions
{
    private readonly IParserFactory _factory;

    private readonly IAuthorizationFactory _authFactory;

    public IAuthorization Authorization { get; private set; }

    public IParser Parser { get; private set; }

    private readonly ChromeDriver _driver;

    private readonly AuthorizationOptions _authorizationOptions;

    private readonly ParsingOptions _parsingOptions;
    
    public ApplicationOptions(ChromeDriver driver,
        AuthorizationOptions authorizationOptions,
        ParsingOptions parsingOptions,
        IParserFactory factory,
        IAuthorizationFactory authFactory)
    {
        _driver = driver;
        _factory = factory;
        _authFactory = authFactory;
        _parsingOptions = parsingOptions;
        _authorizationOptions = authorizationOptions;
    }
    

    public void UseAuthorization<T>() where T:IAuthorization
    {
        Authorization = _authFactory.CreateAuthorization<T>(_authorizationOptions,_driver);
    }

    public void UseParser<T>() where T:IParser
    {
       Parser = _factory.CreateProfileParser<T>(_parsingOptions,_driver);
    }

    public void Close()
    {
        _driver.Close();
        _driver.Quit();
    }
}