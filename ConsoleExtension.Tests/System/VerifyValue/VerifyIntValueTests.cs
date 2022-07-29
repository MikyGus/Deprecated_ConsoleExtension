using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.VerifyValue;
using FluentAssertions;

namespace ConsoleExtension.Tests.System.VerifyValue;

public class VerifyIntValueTests
{

    [Fact]
    public void Verify_ShouldReturnResultInt_WhenInputIsAnInt()
    {
        var sut = 42.Verify(x => x > 4);
        sut.Should().BeOfType<Result<int>>();
    }
}
