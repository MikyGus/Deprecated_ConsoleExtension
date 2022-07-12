using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using FluentAssertions;
using System.Globalization;

namespace ConsoleExtension.Tests.System.ValueConverter
{
    public class ConvertStringToDoubleTests
    {

        [Fact]
        public void ConvertToDouble_ShouldReturnSuccessValue1_WhenStringIs1AndCultureSwe()
        {
            // Arrange
            string input = "1,1";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("sv-SE");
            // Act
            IResult<double> result = input.ConvertToDouble(0,culture);
            // Assert
            result.Should().BeOfType(typeof(ResultSuccess<double>));
            result.Value.Should().Be(1.1);
        }
        [Fact]
        public void ConvertToDouble_ShouldReturnSuccessValue1_WhenStringIs1AndCultureDefault()
        {
            // Arrange
            string input = "1.1";
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
        [Fact]
        public void ConvertToDouble_ShouldReturnFailedValue999_WhenStringIsNotConvertableToDoubleAndDefaultSetTo999()
        {
            // Arrange
            string input = "IAmNotConvertibleToDouble";
            // Act
            IResult<double> result = input.ConvertToDouble(999);
            // Assert
            result.Should().BeOfType(typeof(ResultFailed<double>));
            result.Value.Should().Be(999);
        }
    }
}
