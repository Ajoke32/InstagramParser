using OpenQA.Selenium.Chrome;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Authorization;
using ProfileParser.Data;
using ProfileParser.Factories;
using ProfileParser.Options;

namespace ProfileParser.Abstraction;

public abstract class ParserAppBase:IParserApp
{
    public ApplicationOptions ApplicationOptions { get; }
    
    public IAuthorizationFactory  AuthorizationFactory { get; }
    
    public IParserAppFactory ParserAppFactory { get; }
    public ParserAppBase(ApplicationOptions options,IAuthorizationFactory authFactory,IParserAppFactory appFactory)
    {
       ApplicationOptions = options;
       AuthorizationFactory = authFactory;
       ParserAppFactory = appFactory;
    }

    public virtual void SetupBasicConfig()
    {
        
    }

    public void UseDriverConfig(Action<ApplicationOptions> cd)
    {
        cd(ApplicationOptions);
    }
    

    public void Save(ISaveDataStrategy dataSaver)
    {
        ///dataSaver.Save();
    }

    public virtual void Start()
    {
        
    }
}