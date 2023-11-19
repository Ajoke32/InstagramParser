namespace ProfileParser.Utils;

public class SelectorConverter
{
    public static string ConvertToSelector(string tagName, string className)
    {
        return $"{tagName}.{className.Replace(' ','.')}";
    }
}