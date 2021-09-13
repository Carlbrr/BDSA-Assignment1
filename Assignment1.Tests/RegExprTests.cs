using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_input_lines_split_and_return_words()
        {
        //Given
        IEnumerable<string> input = new List<string>(){"Hello, my", "name is Caws123"};

        //When
        var output = RegExpr.SplitLine(input);

        //Then
        var expected = new List<string>(){"Hello", "my", "name", "is", "Caws123"};
        Assert.Equal(expected, output);
        }

        [Fact]
        public void SplitLine_input_with_special_characters_should_and_return_words_without_special_characters()
        {
        //Given
        IEnumerable<string> input = new List<string>(){"@Hello, my£", "name> is Caws123%"};

        //When
        var output = RegExpr.SplitLine(input);

        //Then
        var expected = new List<string>(){"Hello", "my", "name", "is", "Caws123"};
        Assert.Equal(expected, output);
        }
    }
}
