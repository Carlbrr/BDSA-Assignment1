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

        [Fact]
        public void stringResolutions_convert_1920x1080()
        {
        //Given
        IEnumerable<string> input = new List<string>(){"1920x1080"};

        //When
        IEnumerable<(int width, int height)> output = RegExpr.Resolution(input);

        //Then
        IEnumerable<(int width, int height)> expected = new List<(int width, int height)>(){(1920, 1080)};
        Assert.Equal(expected,output);
        }

        [Fact]
        public void stringResolutions_convert_1920x1080_and_1024x768()
        {
        //Given
        IEnumerable<string> input = new List<string>(){"1920x1080, 1024x768"};
        
        //When
        IEnumerable<(int width, int height)> output = RegExpr.Resolution(input);
        
        //Then
        IEnumerable<(int width, int height)> expected = new List<(int width, int height)>(){(1920, 1080), (1024, 768)};
        Assert.Equal(expected,output);
        }

        [Fact]
        public void stringResolutions_convert_8input_to_tuples()
        {
        //Given
        IEnumerable<string> input = new List<string>(){"1920x1080", "1024x768, 800x600, 640x480","320x200, 320x240, 800x600", "1280x960"};

        //When
        IEnumerable<(int width, int height)> output = RegExpr.Resolution(input);
        
        //Then
        IEnumerable<(int width, int height)> expected = new List<(int width, int height)>(){(1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960)};
        Assert.Equal(expected,output);
        }
    }
}
