//using ConsoleExtension.Library.Result;
//using ConsoleExtension.Library.Rules;
//using FluentAssertions;

//namespace ConsoleExtension.Tests.System.Rules
//{
//    public class VerifyIntOverValueTests
//    {

//        public class WhenInputIsResultFailed
//        {
//            //[Fact]
//            //public void VerifyOverValue_ShouldConvertToFailedWithAddedMessage_WhenInputValue4IsNOTOver5()
//            //{
//            //    // Arrange
//            //    Mock<IResultFailed<int>> mockResult = new(MockBehavior.Strict);
//            //    mockResult.Setup(x => x.Value).Returns(4);
//            //    mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//            //    //mockResult.Setup(x => x.ConvertToFail())
//            //    //    .Returns(new ResultFailed<int>(4));
//            //    // Act
//            //    _ = mockResult.Object.VerifyOver(5);
//            //    // Assert
//            //    mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//            //    mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Once);
//            //    //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//            //}
//            //[Fact]
//            //public void VerifyOverValue_ShouldConvertToFailedWithNOAddedMessage_WhenInputValue4ISOver3()
//            //{
//            //    // Arrange
//            //    Mock<IResultFailed<int>> mockResult = new(MockBehavior.Strict);
//            //    mockResult.Setup(x => x.Value).Returns(4);
//            //    mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//            //    //mockResult.Setup(x => x.ConvertToFail())
//            //    //    .Returns(new ResultFailed<int>(4));
//            //    // Act
//            //    _ = mockResult.Object.VerifyOver(3);
//            //    // Assert
//            //    mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//            //    mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Never);
//            //    //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//            //}

//            [Fact]
//        public void VerifyOverValue_ShouldReturnFailed_WhenInputIsFailedRegardlessOfValues()
//        {
//            // Arrange
//            IResult<int> result = new ResultFailed<int>(4);
//            // Act
//            IResult<int> sutBelow = result.VerifyOver(5);
//            IResult<int> sutEqual = result.VerifyOver(4);
//            IResult<int> sutOver = result.VerifyOver(3);

//            // Assert
//            sutBelow.Should().BeOfType<ResultFailed<int>>();
//            sutEqual.Should().BeOfType<ResultFailed<int>>();
//            sutOver.Should().BeOfType<ResultFailed<int>>();
//        }
//    }

//    public class WhenInputIsResultSuccess
//    {
//        //[Fact]
//        //public void VerifyOverValue_ShouldConvertToFailedWithAddedMessage_WhenInputValue4IsNOTOver5()
//        //{
//        //    // Arrange
//        //    Mock<IResultSuccess<int>> mockResult = new(MockBehavior.Strict);
//        //    mockResult.Setup(x => x.Value).Returns(4);
//        //    mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//        //    //mockResult.Setup(x => x.ConvertToFail())
//        //    //    .Returns(new ResultFailed<int>(4));
//        //    // Act
//        //    _ = mockResult.Object.VerifyOver(5);
//        //    // Assert
//        //    mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//        //    mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Once);
//        //    //mockResult.Verify(x => x.ConvertToFail(), Times.Once);
//        //}
//        //[Fact]
//        //public void VerifyOverValue_ShouldConvertToSuccessWithNOAddedMessage_WhenInputValue4ISOver3()
//        //{
//        //    // Arrange
//        //    Mock<IResultSuccess<int>> mockResult = new(MockBehavior.Loose);
//        //    mockResult.Setup(x => x.Value).Returns(4);
//        //    mockResult.Setup(x => x.AddResultMessage(It.IsAny<string>()));
//        //    // Act
//        //    _ = mockResult.Object.VerifyOver(3);
//        //    // Assert
//        //    mockResult.Verify(x => x.Value, Times.AtLeastOnce);
//        //    mockResult.Verify(x => x.AddResultMessage(It.IsAny<string>()), Times.Never);
//        //}

//        [Fact]
//        public void VerifyOverValue_ShouldReturnSuccess_WhenInputIsSuccessANDValueISOver()
//        {
//            // Arrange
//            IResult<int> result = new ResultSuccess<int>(4);
//            // Act
//            IResult<int> sutBelow = result.VerifyOver(5);
//            IResult<int> sutEqual = result.VerifyOver(4);
//            IResult<int> sutOver = result.VerifyOver(3);

//            // Assert
//            sutBelow.Should().BeOfType<ResultFailed<int>>();
//            sutEqual.Should().BeOfType<ResultFailed<int>>();
//            sutOver.Should().BeOfType<ResultSuccess<int>>();
//        }
//    }
//}
//}
