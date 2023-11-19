using ProfileParser.Enums;

namespace ProfileParser.Options;

public  class AuthorizationOptions
{
    public string LoginFieldIdentifier { get; set; } = string.Empty;

    public string PasswordFieldIdentifier { get; set; } = string.Empty;

    public string ErrorSection { get; set; } = string.Empty;
    
    public string LoginButton { get; set; } = string.Empty;
    
    public string LogInSuccessElement { get; set; }= string.Empty; 
    
    public AllowedLoginMethod LoginMethods { get; set; }
}