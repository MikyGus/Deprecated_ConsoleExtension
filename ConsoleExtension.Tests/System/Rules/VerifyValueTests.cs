using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.Rules;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.Rules;

public class VerifyValueTests
{

    [Fact]
    public void Verify_ShouldReturnInstanceOfIVerify_WhenCalledOnIResult()
    {
        // Arrange
        IResult<int> result = new ResultFactory<int>().Create(0, 5, true);
        // Act
        var sut = result.Verify();
        // Assert
        sut.Should().BeAssignableTo<IVerifyResult<int>>();
    }
}
