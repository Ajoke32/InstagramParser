namespace ProfileParser.Entities;

public class User
{
    public string UserName { get; set; } = string.Empty;

    public string Posts { get; set; } = string.Empty;

    public string Followers { get; set; } = string.Empty;

    public string Following { get; set; } = string.Empty;
    

    public string SecondName { get; set; } = string.Empty;
    
    public string AccountAbout { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public string DateJoined { get; set; } = string.Empty;
    
    public string FormerUserName { get; set; } = string.Empty;

    public string Site { get; set; } = string.Empty;

    public bool IsPrivate { get; set; } = false;
    public List<Link> Links { get; set; } = new();
}