using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.VerifyValue;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.VerifyValue;

public class VerifyResultTTests
{

    [Fact]
    public void Verify_ShouldReturnResultT_WhenInputIsAnResultT()
    {
        IResult<int> InputResult = ResultFactory<int>.Create(42, 0, true);
        var result = InputResult.Verify(x => x > 5);
        result.Should().BeOfType<Result<int>>();
    }
}
