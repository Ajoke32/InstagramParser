namespace ProfileParser.Options;

public abstract class ProfileParsingOptions
{
    public string FollowersSection { get; set; } = string.Empty; // or friends section

    public string FollowerPageLink { get; set; } = string.Empty; 

    public string NickNameBlock { get; set; } = string.Empty;

    public string FollowersBlock { get; set; } = string.Empty; // or friends block/list

    public string FollowingBlock { get; set; } = string.Empty; // or friends count

    public string About { get; set; } = string.Empty;

    public string ToAccount { get; set; } = string.Empty;

}