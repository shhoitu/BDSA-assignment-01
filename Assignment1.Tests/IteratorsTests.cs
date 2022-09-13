namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]	
	public void Flatten_given_nested_list_0_1_5_and_8_2_returns_list_0_1_5_8_2() {
		// Arrange
		List<int> n1 = (new[] {0, 1, 5}).ToList();
		List<int> n2 = (new[] {8, 2}).ToList();
		List<List<int>> list = new List<List<int>>();
		list.Add(n1);
		list.Add(n2);

		// Act
		var result = Iterators.Flatten<int>(list);
		
		// Assert
		Assert.Equal((new[] {0, 1, 5, 8, 2}).ToList(), result);
	}
}