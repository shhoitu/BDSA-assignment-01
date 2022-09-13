namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Helloworld_split_in_two(){
        //Arrange
        string[] hw = {"Hello World", "Mikkel og Clara"};

        //Act
        var split = RegExpr.SplitLine(hw);

        //Assert
        string[] excpect =  {"Hello","World", "Mikkel", "og", "Clara"} ;
        Assert.Equal(excpect , split );
    }   
}