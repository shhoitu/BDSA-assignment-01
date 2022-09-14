namespace Assignment1.Tests;

public class ResolutionsTests
{
    [Fact]
    public void StringToTuples()
    {
        // Arrange
        string[] input = { "1920x1080", "1024x768, 800x600, 640x480" };

        // Act
        var result = RegExpr.Resolution(input);

        // Assert
        (int, int)[] except = new (int, int)[] { (1920, 1080), (1024, 768), (800, 600), (640, 480) };
        Assert.Equal(except, result);
    }
}