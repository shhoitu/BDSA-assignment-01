namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void array_of_two_lines_split_in_five(){
        //Arrange
        string[] hw = {"Hello World", "Mikkel og Clara"};

        //Act
        var split = RegExpr.SplitLine(hw);

        //Assert
        string[] excpect =  {"Hello","World", "Mikkel", "og", "Clara"} ;
        Assert.Equal(excpect , split );
    } 

    [Fact]
    public void ending_on_exclamation()
    {
        //Arrange
        string[] hw = {"Hello World!"};

        //Act
        var split = RegExpr.SplitLine(hw);

        //Assert
        string[] excpect =  {"Hello", "World", ""} ;
        Assert.Equal(excpect , split );
    }  

    [Fact]
    public void testing_input_from_assignment()
    {
         //Arrange
         IEnumerable<string> test =  new List <string> {
            "1920x1080", "1024x768"," 800x600", "640x480",
            "320x200", "320x240", "800x600","1280x960"     
            };

        //Act
        var actual = RegExpr.Resolution(test);

        //Assert
        IEnumerable<(int width, int height)> excpect =  new List <(int width, int height)> {
            (1920, 1080), (1024, 768),(800, 600),
            (640, 480), (320, 200), (320, 240),
            (800, 600), (1280, 960)
            } ;
        Assert.Equal(excpect , actual);
    }
}