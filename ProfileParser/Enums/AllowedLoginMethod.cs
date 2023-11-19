namespace ProfileParser.Enums;

[Flags]
public enum AllowedLoginMethod
{
    UserName=1,
    Email = 2,
    PhoneNumber=4
}