using ConsoleExtension.Library.DataModifiers;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.DataModifiers;

public class StringModifierTests
{

    [Fact]
    public void Truncate_ShouldReturnString1234_WhenInputString_123456789_AndMaxLength4()
    {
        // Arrange
        StringModifier sut = new();
        string testString = "123456789";
        // Act
        String result = sut.Truncate(testString, 4);
        // Assert
        result.Should().Be("1234");
    }

    [Fact]
    public void Truncate_ShouldReturnString12_WhenInputString_12_AndMaxLength4()
    {
        // Arrange
        StringModifier sut = new();
        string testString = "12";
        // Act
        String result = sut.Truncate(testString, 4);
        // Assert
        result.Should().Be("12");
    }

    [Fact]
    public void Padding_ShouldReturnStringxxx12_WhenInputString_12_Width5FillWithxAlign1()
    {
        // Arrange
        StringModifier sut = new();
        string testString = "12";
        int width = 5;
        char fillChar = 'x';
        Alignment alignment = Alignment.RIGHT;
        // Act
        String result = sut.Padding(testString, alignment, width, fillChar);
        // Assert
        result.Should().Be("xxx12");
    }
    [Fact]
    public void Padding_ShouldReturnStringx12xx_WhenInputString_12_Width5FillWithxAlign0()
    {
        // Arrange
        StringModifier sut = new();
        string testString = "12";
        int width = 5;
        char fillChar = 'x';
        Alignment alignment = Alignment.CENTER;
        // Act
        String result = sut.Padding(testString, alignment, width, fillChar);
        // Assert
        result.Should().Be("x12xx");
    }
    [Fact]
    public void Padding_ShouldReturnString12xxx_WhenInputString_12_Width5FillWithxAlignM1()
    {
        // Arrange
        StringModifier sut = new();
        string testString = "12";
        int width = 5;
        char fillChar = 'x';
        Alignment alignment = Alignment.LEFT;
        // Act
        String result = sut.Padding(testString, alignment, width, fillChar);
        // Assert
        result.Should().Be("12xxx");
    }

    [Fact]
    public void Padding_ShouldReturnStringxxxxx_WhenInputString_null_Width5FillWithxAlignLeft()
    {
        // Arrange
        StringModifier sut = new();
        int? testValue = null;
        int width = 5;
        char fillChar = 'x';
        Alignment alignment = Alignment.LEFT;
        // Act
        String result = sut.Padding(testValue, alignment, width, fillChar);
        // Assert
        result.Should().Be("xxxxx");
    }
}
