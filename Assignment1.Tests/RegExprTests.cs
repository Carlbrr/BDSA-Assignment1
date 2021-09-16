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
        IEnumerable<string> input = new List<string>(){"@Hello, my>", "name> is Caws123%"};

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

        [Fact]
        public void InnerText_get_tag_a_returns_theoretical_computer_science()
        {
        //Given
         string input = new string("<a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a>");
        
        //When
           IEnumerable<string> output = RegExpr.InnerText(input, "a");
           IEnumerable<string> expected = new List<string>(){"theoretical computer science"};

        //Then
            Assert.Equal(expected, output);
        }

        [Fact]
        public void InnerText_get_tag_a_returns_multiple_innerText()
        {
        //Given
         string input = new string("<p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>");
        
        //When
           IEnumerable<string> output = RegExpr.InnerText(input, "a");
           IEnumerable<string> expected = new List<string>(){"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"};

        //Then
            Assert.Equal(expected, output);
        }

        [Fact]
        public void InnerText_get_tag_p_returns_nested() // This feature is not implemented
        {
        //Given
         string input = new string("<div> <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p> </div>");
        
        //When
           IEnumerable<string> output = RegExpr.InnerText(input, "p");
           IEnumerable<string> expected = new List<string>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

        //Then
            Assert.Equal(expected, output);
        }
    }
}
