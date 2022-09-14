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
                var match = Regex.Matches(line, regex);

                foreach(Match number in match)
                {
                    GroupCollection groups = number.Groups;
                
                    yield return (int.Parse(groups["width"].Value), int.Parse(groups["height"].Value));
                }
            }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}