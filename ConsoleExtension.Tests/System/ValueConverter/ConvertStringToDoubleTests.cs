using ConsoleExtension.Library.Converters;
using FluentAssertions;
using System.Globalization;

namespace ConsoleExtension.Tests.System.ValueConverter;

public class ConvertStringToDoubleTests
{

    [Fact]
    public void ConvertStringToDouble_ShouldReturnSuccessful1d1_WhenInputStringIs1comma1AndCultureSwe()
    {
        // Arrange
        string inputString = "1,1";
        CultureInfo culture = CultureInfo.CreateSpecificCulture("sv-SE");
        // Act
        var result = inputString.ConvertToDouble(culture);
        // Assert
        result.IsSuccessful.Should().BeTrue();
        result.Value.Should().Be(1.1);
        result.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void ConvertStringToDouble_ShouldReturnSuccessful1d1_WhenInputStringIs1d1AndCultureNotSpecified()
    {
        // Arrange
        string inputString = "1.1";
        // Act
        var result = inputString.ConvertToDouble();
        // Assert
        result.IsSuccessful.Should().BeTrue();
        result.Value.Should().Be(1.1);
        result.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void ConvertStringToDouble_ShouldReturnNOTSuccessful0_WhenInputStringIsInvalidDouble()
    {
        // Arrange
        string inputString = "NotANumber";
        CultureInfo culture = CultureInfo.CreateSpecificCulture("sv-SE");
        // Act
        var result = inputString.ConvertToDouble(culture);
        // Assert
        result.IsSuccessful.Should().BeFalse();
        result.Value.Should().Be(0);
        result.ResultMessages.Should().HaveCount(1);
    }

    [Fact]
    public void ConvertStringToDouble_ShouldReturnNOTSuccessful99d99_WhenInputStringIsInvalidDoubleDefault99d9()
    {
        // Arrange
        string inputString = "NotANumber";
        CultureInfo culture = CultureInfo.CreateSpecificCulture("sv-SE");
        double defaultValue = 99.9d;
        // Act
        var result = inputString.ConvertToDouble(culture, defaultValue);
        // Assert
        result.IsSuccessful.Should().BeFalse();
        result.Value.Should().Be(defaultValue);
        result.ResultMessages.Should().HaveCount(1);
    }
}
