using ConsoleExtension.Library.Converters;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.ValueConverter;


public class ConvertStringToIntTests
{

    [Fact]
    public void ConvertToInt_ShouldReturnSuccessfulValue1NoMessages_WhenValidInputstring1()
    {
        // Arrange
        string inputString = "1";
        // Act
        var result = inputString.ConvertToInt();
        // Assert
        result.IsSuccessful.Should().BeTrue();
        result.Value.Should().Be(1);
        result.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void ConvertToInt_ShouldReturnFailureValue0And1Message_WhenInvalidInputstring()
    {
        // Arrange
        string inputString = "I'm not a valid integer";
        // Act
        var result = inputString.ConvertToInt();
        // Assert
        result.IsSuccessful.Should().BeFalse();
        result.Value.Should().Be(0);
        result.ResultMessages.Should().HaveCount(1);
    }

    [Fact]
    public void ConvertToInt_ShouldReturnFailureDefault99_WhenInvalidInputstringAndDefault99()
    {
        // Arrange
        string inputString = "I'm not a valid integer";
        int defaultValue = 99;
        // Act
        var result = inputString.ConvertToInt(defaultValue);
        // Assert
        result.Value.Should().Be(defaultValue);
    }
}