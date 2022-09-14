namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void array_of_two_lines_split_in_five(){
        //Arrange
        string[] input = {"Hello World", "Mikkel og Clara"};

        //Act
        var actual = RegExpr.SplitLine(input);

        //Assert
        string[] excpect =  {"Hello","World", "Mikkel", "og", "Clara"} ;
        Assert.Equal(excpect , actual);
    } 

    [Fact]
    public void ending_on_exclamation()
    {
        //Arrange
        string[] input = {"Hello World!"};

        //Act
        var actual = RegExpr.SplitLine(input);

        //Assert
        string[] excpect =  {"Hello", "World", ""} ;
        Assert.Equal(excpect , actual);
    }  

    [Fact]
    public void testing_input_from_assignment()
    {
         //Arrange
         IEnumerable<string> input =  new List <string>
        {"1920x1080", "1024x768"," 800x600", "640x480", "320x200", "320x240", "800x600","1280x960"};

        //Act
        var actual = RegExpr.Resolution(input);

        //Assert
        IEnumerable<(int width, int height)> excpect =  new List <(int width, int height)>
        {(1920, 1080), (1024, 768),(800, 600), (640, 480), (320, 200), (320, 240),(800, 600), (1280, 960)};
        Assert.Equal(excpect , actual);
    }

    [Fact]
    public void innerText_example_from_assignment_not_nested()
    {
        //Arrange
        string input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        
        //Act
        var actual = RegExpr.InnerText(input, "a");

        //Assert
        IEnumerable<string> expected =  new List <string> 
        {"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void innerText_example_from_assignment_nested()
    {
        //Arrange
        string input = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        
        //Act
        var actual = RegExpr.InnerText(input, "p");

        //Assert
        IEnumerable<string> expected =  new List <string> 
        {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void urls_should_return_wikipedia_and_titles()
    {
         //Arrange
        string input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        
        //Act
        var actual = RegExpr.Urls(input);

        //Assert
        IEnumerable<(Uri url, string title)> expected =  new List <(Uri url, string title)>
        {
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), 
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
            
        };
        Assert.Equal(expected, actual);
    }
}