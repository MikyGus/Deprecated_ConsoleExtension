using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.VerifyValue;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.VerifyValue;

public class VerifyResultValueTests
{

    [Fact]
    public void Verify_ShouldReturnSuccess_WhenInputSuccessAndTrue()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => true);
        // Assert
        resultValue.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputSuccessAndFalse()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => false);
        // Assert
        resultValue.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputFailedAndTrue()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, false);
        // Act
        var resultValue = resultClass.Verify(x => true);
        // Assert
        resultValue.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputFailedAndFalse()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, false);
        // Act
        var resultValue = resultClass.Verify(x => false);
        // Assert
        resultValue.IsSuccessful.Should().BeFalse();
    }


    [Fact]
    public void Verify_ShouldReturnResultWithOneNewMessage_WhenEvaluateIsFalse()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => false, "We have an error");
        // Assert
        resultValue.ResultMessages.Should().HaveCount(1);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsTrue()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => true, "We have an error");
        // Assert
        resultValue.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsFalseAndMessageIsEmpty()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => false);
        // Assert
        resultValue.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsTrueAndMessageIsEmpty()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var resultValue = resultClass.Verify(x => true);
        // Assert
        resultValue.ResultMessages.Should().HaveCount(0);
    }
}
