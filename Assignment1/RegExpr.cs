namespace Assignment1;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;


public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) 
    {
        var regex = "[^0-9a-zA-Z]+";
        // The regex string

        foreach (string line in lines)
         {
            var split = Regex.Split(line, regex);
            //Use Regex.Split to split the line where the regex fits
            
                 foreach (string regexLine in split)
                {
                    yield return regexLine;
                    //returns the individual words
                    //yield statement used to return each element one at a time
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
                    //Regex.Matches returns a collection of match objects that are found 
                    //when comparing a line to the regex expression

                    GroupCollection groups = number.Groups;
                    //Returns the set of captured groups in a single match.
                    //So the first part of an expression has the value width, the second the value height

                    int w = int.Parse(groups["width"].Value);
                    int h = int.Parse(groups["height"].Value);
                
                    yield return (w , h);
                }
            }
    }

    public static IEnumerable<string> InnerText(string html, string tag) 
    {
        var regex = string.Format(@"<([{0}][^>]*)>(?<innerText>.+?)</{0}>", tag);
        //The format inserts the tag in the regex expression where it says {0}

        foreach (Match match in Regex.Matches(html, regex))
        {
            GroupCollection groups = match.Groups;
            yield return Regex.Replace(groups["innerText"].Value, "<[^>]*>", "");
            //replaces <[^>]*> with nothing ("")
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var regex = @".*?href=""(?<url>\S*)"".*?(title=""(?<title>.*?)"".*?)?>(?<innerText>.*?)<";

        foreach (Match match in Regex.Matches(html, regex))
        {
            
               Uri url = new Uri(match.Groups["url"].Value);
               //makes the uri

                var title = match.Groups["title"].Value;
                var innerText = match.Groups["innerText"].Value;
            
                if (title != "") yield return (url, title);
                else yield return ((url, innerText));
            
        }
    }
}