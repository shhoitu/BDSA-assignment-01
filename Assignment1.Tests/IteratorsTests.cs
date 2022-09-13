namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]	
	public void Flatten_given_nested_list_0_1_5_and_8_2_returns_0_1_5_8_2() {
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

    [Fact]
    public void Flatten_given_nested_list_0_1_5_and_empty_list_returns_0_1_5() {
		// Arrange
		List<int> n1 = (new[] {0, 1, 5}).ToList();
		List<int> n2 = new List<int>();
		List<List<int>> list = new List<List<int>>();
		list.Add(n1);
		list.Add(n2);

		// Act
		var result = Iterators.Flatten<int>(list);
		
		// Assert
		Assert.Equal((new[] {0, 1, 5}).ToList(), result);
	}

    [Fact]
    public void Flatten_given_nested_hey_you_and_over_there_returns_hey_you_over_there() {
		// Arrange
		List<string> n1 = (new[] {"hey", "you"}).ToList();
		List<string> n2 = (new[] {"over", "there"}).ToList();
		List<List<string>> list = new List<List<string>>();
		list.Add(n1);
		list.Add(n2);

		// Act
		var result = Iterators.Flatten<string>(list);
		
		// Assert
		Assert.Equal(new List<string>(new[] {"hey", "you", "over", "there"}), result);
	}
}