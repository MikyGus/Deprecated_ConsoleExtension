using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using FluentAssertions;

namespace ConsoleExtension.Tests.System.ValueConverter
{
    public class ConvertStringToIntTests
    {

        public class WhenGivenString1
        {
            [Fact]
            public void ConvertToInt_ShouldReturnResultSuccess()
            {
                // Arrange
                string input = "1";
                // Act
                IResult<int> result = input.ConvertToInt();
                // Assert
                result.Should().BeOfType(typeof(ResultSuccess<int>));
            }

            [Fact]
            public void ConvertToInt_ShouldReturnResultSetWithValue1()
            {
                // Arrange
                string input = "1";
                // Act
                IResult<int> result = input.ConvertToInt();
                // Assert
                result.Value.Should().Be(1);
            }

        }

        public class WhenGivenStringUnableToConvertToInteger
        {
            [Fact]
            public void ConvertToInt_ShouldReturnResultSetWithDefaultValue0()
            {
                // Arrange
                string input = "NotANumber";
                // Act
                IResult<int> result = input.ConvertToInt();
                // Assert
                result.Value.Should().Be(0);
            }

            [Fact]
            public void ConvertToInt_ShouldReturnResultFailed()
            {
                // Arrange
                string input = "NotANumber";
                // Act
                IResult<int> result = input.ConvertToInt();
                // Assert
                result.Should().BeOfType(typeof(ResultFailed<int>));
            }
        }

    }
}
