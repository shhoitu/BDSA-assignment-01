namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) => throw new NotImplementedException();

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        foreach (string str in resolutions)
        {
            string[] temp = Regex.Split(str, @"\,\x");
            
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}