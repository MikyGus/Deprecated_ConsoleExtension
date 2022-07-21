//using ConsoleExtension.Library.Result;
//using ConsoleExtension.Library.Rules;
//using FluentAssertions;
//using Moq;

using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.Rules;
using FluentAssertions;
using Moq;
using Xunit;
namespace ConsoleExtension.Tests.System.Rules;

public class VerifyIntBelowValueTests
{

    [Fact]
    public void VerifyBelowValue_ShouldVerifySuccess_WhenInputResultSuccessAndValue5IsUnder10()
    {
        // Arrange
        int DefaultValue = 0;
        int Value = 5;
        bool IsSuccessful = true;
        IVerifyResult<int> verifySuccess = new VerifyResult<int>(DefaultValue, Value, IsSuccessful);
        // Act
        var result = verifySuccess.IsUnderValue(10);
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void VerifyBelowValue_ShouldVerifyFailed_WhenInputResultSuccessAndValue100IsUnder10()
    {
        // Arrange
        int DefaultValue = 0;
        int Value = 100;
        bool IsSuccessful = true; 
        IVerifyResult<int> verifySuccess = new VerifyResult<int>(DefaultValue,Value,IsSuccessful);
        // Act
        var result = verifySuccess.IsUnderValue(10);
        // Assert
        result.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    public void VerifyBelowValue_ShouldVerifyFailed_WhenInputResultFailedAndValue5IsUnder10()
    {
        // Arrange
        int DefaultValue = 0;
        int Value = 5;
        bool IsSuccessful = false;
        IVerifyResult<int> verifyFailed = new VerifyResult<int>(DefaultValue, Value, IsSuccessful);
        // Act
        var result = verifyFailed.IsUnderValue(10);
        // Assert
        result.IsSuccessful.Should().BeFalse();
    }
}

//{
//    public class VerifyIntBelowValueTests
//    {

//        public class WhenInputIsResultFailed
//        {

//            [Fact]
//            public void VerifyBelowValue_ShouldConvertToFailedWithAddedMessage_WhenInputValue4IsNOTBelow3()
//            {
//                // Arrange
//                var mockResult = new Mock<IResultFailed<int>>(MockBehavior.Strict);
//                mockResult.Setup(x => x.Value).Returns(4);
//                mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//                //mockResult.Setup(x => x.ConvertToFail())
//                //    .Returns(new ResultFailed<int>(4));
//                // Act
//                _ = mockResult.Object.VerifyBelow(3);
//                // Assert
//                mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//                mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Once);
//                //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//            }

//            [Fact]
//            public void VerifyBelowValue_ShouldConvertToFailedWithNOAddedMessage_WhenInputValue4ISBelow5()
//            {
//                // Arrange
//                var mockResult = new Mock<IResultFailed<int>>(MockBehavior.Strict);
//                mockResult.Setup(x => x.Value).Returns(4);
//                mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//                //mockResult.Setup(x => x.ConvertToFail())
//                //    .Returns(new ResultFailed<int>(4));
//                // Act
//                _ = mockResult.Object.VerifyBelow(5);
//                // Assert
//                mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//                mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Never);
//                //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//            }

//            [Fact]
//            public void VerifyBelowValue_ShouldReturnFailed_WhenInputIsFailedRegardlessOfValues()
//            {
//                // Arrange
//                IResult<int> result = new ResultFailed<int>(4);
//                // Act
//                IResult<int> sutBelow = result.VerifyBelow(5);
//                IResult<int> sutEqual = result.VerifyBelow(4);
//                IResult<int> sutOver = result.VerifyBelow(3);

//                // Assert
//                sutBelow.Should().BeOfType<ResultFailed<int>>();
//                sutEqual.Should().BeOfType<ResultFailed<int>>();
//                sutOver.Should().BeOfType<ResultFailed<int>>();
//            }
//        }

//        public class WhenInputIsResultSuccess
//        {
//            [Fact]
//            public void VerifyBelowValue_ShouldConvertToFailedWithAddedMessage_WhenInputValue4IsNOTBelow3()
//            {
//                // Arrange
//                var mockResult = new Mock<IResultSuccess<int>>(MockBehavior.Strict);
//                mockResult.Setup(x => x.Value).Returns(4);
//                mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//                //mockResult.Setup(x => x.ConvertToFail())
//                //    .Returns(new ResultFailed<int>(4));
//                // Act
//                _ = mockResult.Object.VerifyBelow(3);
//                // Assert
//                mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//                mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Once);
//                //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//            }

//            [Fact]
//            public void VerifyBelowValue_ShouldConvertToSuccessWithNOAddedMessage_WhenInputValue4ISBelow5()
//            {
//                // Arrange
//                var mockResult = new Mock<IResultSuccess<int>>(MockBehavior.Strict);
//                mockResult.Setup(x => x.Value).Returns(4);
//                mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//                //mockResult.Setup(x => x.ConvertToSuccess())
//                //    .Returns(new ResultSuccess<int>(4));
//                // Act
//                _ = mockResult.Object.VerifyBelow(5);
//                // Assert
//                mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//                mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Never);
//                //mockResult.Verify(x => x.ConvertToSuccess(), Times.Once);
//            }

//            [Fact]
//            public void VerifyBelowValue_ShouldReturnSuccess_WhenInputIsSuccessANDValueISBelow()
//            {
//                // Arrange
//                IResult<int> result = new ResultSuccess<int>(4);
//                // Act
//                IResult<int> sutBelow = result.VerifyBelow(5);
//                IResult<int> sutEqual = result.VerifyBelow(4);
//                IResult<int> sutOver = result.VerifyBelow(3);

//                // Assert
//                sutBelow.Should().BeOfType<ResultSuccess<int>>();
//                sutEqual.Should().BeOfType<ResultFailed<int>>();
//                sutOver.Should().BeOfType<ResultFailed<int>>();
//            }
//        }

//    }
//}
