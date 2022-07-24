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


    [Fact]
    public void Verify_ShouldReturnResultWithTwoMessages_WhenEvaluateIsFalseAndInputResultWithOneMessage()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, true);
        var result1 = resultClass.Verify(x => false, "We have error 1");
        // Act
        var resultValue = result1.Verify(x => false, "We have error 2");
        // Assert
        resultValue.ResultMessages.Should().HaveCount(2);
    }


    [Fact]
    public void Verify_ShouldReturnResultNoNewMessages_WhenEvaluateIsTrueAndInputResultIsFalse()
    {
        // Arrange
        var resultClass = new ResultFactory<int>().Create(0, 5, false);
        // Act
        var resultValue = resultClass.Verify(x => true, "We have error");
        // Assert
        resultValue.ResultMessages.Should().HaveCount(0);
        resultValue.IsSuccessful.Should().BeFalse();
    }

}
