using OpenQA.Selenium.Chrome;
using ProfileParser;
using ProfileParser.Applications;
using ProfileParser.Authorization;
using ProfileParser.Factories;
using ProfileParser.Options;
using ProfileParser.Parsers;



var driver = new ChromeDriver();
driver.Url = "https://www.instagram.com/";


var authOptions = ApplicationOptionsConfiguration.GetInstagramAuthorizationOptions();

var parsingOptions = ApplicationOptionsConfiguration.GetDefaultInstagramParsingOptions();

var parserFactory = new ParserFactory();

var authFactory = new AuthorizationFactory();

var appOptions = new ApplicationOptions(driver,authOptions,parsingOptions,parserFactory,authFactory);


appOptions.UseAuthorization<InstagramAuthorization>();
appOptions.UseParser<InstagramParser>();

var app = new InstagramParserApp(appOptions);

await app.StartAsync();

