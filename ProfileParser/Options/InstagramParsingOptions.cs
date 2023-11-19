using ProfileParser.Abstraction.Options;


namespace ProfileParser.Options;

public class InstagramParsingOptions:ParsingOptions
{
    public string CloseLogInModalButton { get; set; } = string.Empty;

    public string Home { get; set; } = string.Empty;

    public string SideBar { get; set; } = string.Empty;

    public string FollowerBlock { get; set; } = string.Empty;

    public string UserInfoSection { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string OverallInfo { get; set; } = string.Empty;
    
    public string SecondNameBlock { get; set; } = string.Empty;
    
    public string AccountAbout { get; set; } = string.Empty;

    public string WebSite { get; set; } = string.Empty;
    
    public string BioBlock { get; set; } = string.Empty;
    
    public string LogoutBlock { get; set; } = string.Empty;
    
    public string LogoutButton { get; set; } = string.Empty;
    
    public string SettingsWrapper { get; set; } = string.Empty;
    
    public string SettingsButton { get; set; } = string.Empty;

    public string PrivateAccountBlock { get; set; } = string.Empty;

}