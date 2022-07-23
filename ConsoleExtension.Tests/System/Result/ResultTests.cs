using ConsoleExtension.Library.Result;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.Result;

public class ResultTests
{

    [Fact]
    public void SetToFail_ShouldSetIsSuccessfulToFalse_WhenMethodIsInvoked()
    {
        // Arrange
        IResult<int> sut = new Result<int>(0, 5, true);
        // Act
        sut.SetToFail();
        // Assert
        sut.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void SetToSuccess_ShouldSetIsSuccessfulToTrue_WhenMethodIsInvoked()
    {
        // Arrange
        IResult<int> sut = new Result<int>(0, 5, false);
        // Act
        sut.SetToSuccess();
        // Assert
        sut.IsSuccessful.Should().BeTrue();
    }
}