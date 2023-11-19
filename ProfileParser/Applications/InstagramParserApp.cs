using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Authorization;
using ProfileParser.Factories;
using ProfileParser.Options;

namespace ProfileParser.Applications;

public class InstagramParserApp:ParserAppBase
{
    private readonly InstagramParserApp _instagramParser;

    private readonly IAuthorization _auth;
    
    public InstagramParserApp(ApplicationOptions options,
        IAuthorizationFactory authFactory,
        IParserAppFactory appFactory) : base(options, authFactory, appFactory)
    {
        _auth = authFactory.CreateAuthorization<ProfileAuthorization>();
    }

    public override void Start()
    {
        
    }
}