using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.VerifyValue;
using FluentAssertions;
namespace ConsoleExtension.Tests.System.VerifyValue;

public class VerifyDoubleValueTests
{

    [Fact]
    public void Verify_ShouldReturnResultDouble_WhenInputIsAnDouble()
    {
        var result = 42.0d.Verify(x => x > 4.0);
        result.Should().BeOfType<Result<double>>();
    }
}
