using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void flatten_return_one_stream()
        {
        //Given
        List<List<int>> multiArray = new List<List<int>>();
        multiArray.Add(new List<int>());
        multiArray[0].Add(1);
        multiArray[0].Add(2);
        multiArray.Add(new List<int>());
        multiArray[1].Add(3);
        multiArray[1].Add(4);
        
        //When

        //det erklæres som List istedet for array, da den kun implicit implementerer IEnumerator  
            List<int> expected = new List<int> {1,2,3,4};
            IEnumerable<int> actual = Iterators.Flatten(multiArray);
        //Then

            Assert.Equal(expected, actual);
        }  

        [Fact]
        public void filter_returns_only_on_true_integer_predicate()
        {
            //Arrange
            List<int> argumentList = new List<int>(){1,2,3,4,5,6,7,8,9,10};
            List<int> expected = new List<int>(){2,4,6,8,10};

            //Act
            IEnumerable<int> actual = Iterators.Filter(argumentList,integerPredicate);

            //Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void filter_returns_only_on_true_string_predicate()
        {
            //Arrange
            List<string> argumentList = new List<string>(){"yo","sup","haj","cola","koala","sprit","panda","mobil","java","cskarp"};
            List<string> expected = new List<string>(){"haj","cola","koala","panda","java","cskarp"};
            
            //Act
            IEnumerable<string> actual = Iterators.Filter(argumentList,stringPredicate);

            //Assert
            Assert.Equal(expected,actual);
        }

        //private helper method
        private bool integerPredicate(int x)
        {
            return x%2==0;
        }
        private bool stringPredicate(string y)
        {
            return y.Contains('a');
        }

        }
}

