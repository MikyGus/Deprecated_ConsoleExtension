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
        var resultClass = ResultFactory<int>.Create(5,0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => true);
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputSuccessAndFalse()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => false);
        // Assert
        result.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputFailedAndTrue()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, false);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => true);
        // Assert
        result.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void Verify_ShouldReturnFailed_WhenInputFailedAndFalse()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, false);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => false);
        // Assert
        result.IsSuccessful.Should().BeFalse();
    }


    [Fact]
    public void Verify_ShouldReturnResultWithOneNewMessage_WhenEvaluateIsFalse()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => false, "We have an error");
        // Assert
        result.ResultMessages.Should().HaveCount(1);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsTrue()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => true, "We have an error");
        // Assert
        result.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsFalseAndMessageIsEmpty()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => false);
        // Assert
        result.ResultMessages.Should().HaveCount(0);
    }

    [Fact]
    public void Verify_ShouldReturnResultWithNoNewMessage_WhenEvaluateIsTrueAndMessageIsEmpty()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => true);
        // Assert
        result.ResultMessages.Should().HaveCount(0);
    }


    [Fact]
    public void Verify_ShouldReturnResultWithTwoMessages_WhenEvaluateIsFalseAndInputResultWithOneMessage()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, true);
        var result1 = VerifyResultValue.VerifyValue(resultClass, x => false, "We have error 1");
        // Act
        var result2 = VerifyResultValue.VerifyValue(result1, x => false, "We have error 2");
        // Assert
        result2.ResultMessages.Should().HaveCount(2);
    }


    [Fact]
    public void Verify_ShouldReturnResultNoNewMessages_WhenEvaluateIsTrueAndInputResultIsFalse()
    {
        // Arrange
        var resultClass = ResultFactory<int>.Create(5, 0, false);
        // Act
        var result = VerifyResultValue.VerifyValue(resultClass, x => true, "We have error");
        // Assert
        result.ResultMessages.Should().HaveCount(0);
        result.IsSuccessful.Should().BeFalse();
    }

}
