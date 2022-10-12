using Xunit;
using Services;

namespace test
{
    public class StringCaluclatorTest
    {
        [Fact]
        public void Return0WithEmptyString(){

            var sut = new StringCalculator();

            var result= sut.Add(string.Empty);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("1,2",3)]
        [InlineData("2,3",5)]
        [InlineData("2,3,4",9)]

        public void ReturnsSumGivenStringWithCommaSeparatedNum(string numbers, int expectedResult){
                    
            var sut = new StringCalculator();

            var result= sut.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData("1\n2",3)]
        [InlineData("2\n3",5)]
        [InlineData("2\n3\n4",9)]

        public void ReturnsSumGivenStringWithNewLineSeparatedNum(string numbers, int expectedResult){
                    
            var sut = new StringCalculator();

            var result= sut.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1 2",3)]
        [InlineData("2 3",5)]
        [InlineData("2 3 4",9)]

        public void ReturnsSumGivenStringWithSpaceSeparatedNum(string numbers, int expectedResult){
                    
            var sut = new StringCalculator();

            var result= sut.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2",3)]
        [InlineData("//;\n2;3",5)]
        [InlineData("//-\n2-3-4",9)]

        public void ReturnsSumGivenStringWithCustomSeparatedNum(string numbers, int expectedResult){
                    
            var sut = new StringCalculator();

            var result= sut.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}