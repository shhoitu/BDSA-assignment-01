namespace Assignment1;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;


public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) 
    {
        var regex = "[^0-9a-zA-Z]+";
        foreach (string line in lines)
         {
            var split = Regex.Split(line, regex);
            
                 foreach (string regexLine in split)
                {
                    yield return regexLine;
                }
            

        }
       
    }
    

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) 
    {
        var regex = @"(?<width>\d+)x(?<height>\d+)";
            foreach(string line in resolutions)
            {

                foreach(Match number in Regex.Matches(line, regex))
                {
                    GroupCollection groups = number.Groups;
                
                    yield return (int.Parse(groups["width"].Value), int.Parse(groups["height"].Value));
                }
            }
    }

    public static IEnumerable<string> InnerText(string html, string tag) 
    {
        var regex = string.Format(@"<([{0}][^>]*)>(?<innerText>.+?)</{0}>", tag);

        foreach (Match match in Regex.Matches(html, regex))
        {
            GroupCollection groups = match.Groups;
            yield return Regex.Replace(groups["innerText"].Value, "<[^>]*>", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var regex = @".*?href=""(?<url>\S*)"".*?(title=""(?<title>.*?)"".*?)?>(?<innerText>.*?)<";

        foreach (Match match in Regex.Matches(html, regex))
        {
            if(match.Success)
            {
               Uri url = new Uri(match.Groups["url"].Value);
                string title = match.Groups["title"].Value;
            
                if (title != "") yield return (url, title);
                else yield return ((url, match.Groups["innerText"].Value));
            }
            
        }
    }
}