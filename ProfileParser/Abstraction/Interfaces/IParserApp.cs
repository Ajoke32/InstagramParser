using OpenQA.Selenium.Chrome;
using ProfileParser.Data;
using ProfileParser.Options;

namespace ProfileParser.Abstraction.Interfaces;

public interface IParserApp
{
    public void SetupBasicConfig();

    public void UseDriverConfig(Action<ApplicationOptions> cd);
    
    public void Start();
}