using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.Rules;
using FluentAssertions;

namespace ConsoleExtension.Tests.System.Rules
{
    public class VerifyIntOverValueTests
    {


        [Fact]
        public void VerifyOverValue_ShouldReturnResultFailed_WhenInputValue4IsNotOverComparedValueOf5()
        {
            // Arrange
            IResult<int> sut = new ResultSuccess<int>(4).VerifyOver(5);
            // Act

            // Assert
            sut.Should().BeOfType<ResultFailed<int>>();
        }

        [Fact]
        public void VerifyOverValue_ShouldReturnResultSuccess_WhenInputValue6IsOverComparedValueOf5()
        {
            // Arrange
            IResult<int> sut = new ResultSuccess<int>(6).VerifyOver(5);
            // Act

            // Assert
            sut.Should().BeOfType<ResultSuccess<int>>();
        }
    }
}
