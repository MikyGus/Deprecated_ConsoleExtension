using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using FluentAssertions;

namespace ConsoleExtension.Tests.System.ValueConverter
{
    public class ConvertStringToDoubleTests
    {

        [Fact]
        public void ConvertToDouble_ShouldReturnSuccessValue1_WhenStringIs1()
        {
            // Arrange
            string input = "1,1";
            // Act
            IResult<double> result = input.ConvertToDouble();
            // Assert
            result.Should().BeOfType(typeof(ResultSuccess<double>));
            result.Value.Should().Be(1.1);
        }

        [Fact]
        public void ConvertToDouble_ShouldReturnFailedValue0_WhenStringIsNotConvertableToDouble()
        {
            // Arrange
            string input = "IAmNotConvertibleToDouble";
            // Act
            IResult<double> result = input.ConvertToDouble();
            // Assert
            result.Should().BeOfType(typeof(ResultFailed<double>));
            result.Value.Should().Be(0);
        }
    }
}
