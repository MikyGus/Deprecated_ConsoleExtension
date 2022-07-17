//using ConsoleExtension.Library.Result;
//using ConsoleExtension.Library.Rules;
//using FluentAssertions;
//using Xunit;
//namespace ConsoleExtension.Tests.System.Rules
//{
//    public class BaseVerifyTests
//    {

//        [Fact]
//        public void VerifyValue_ShouldVerifySuccess_WhenInputSuccessAndCompareSuccess()
//        {
//            // Arrange
//            IResult<int> resultInput = new ResultSuccess<int>(5);
//            // Act
//            IResult<int> result = BaseVerify.VerifyValue(resultInput, true, "Testing");
//            // Assert
//            result.Should().BeAssignableTo<IResultSuccess<int>>();
//        }

//        [Fact]
//        public void VerifyValue_ShouldVerifyFailed_WhenInputSuccessAndCompareFailed()
//        {
//            // Arrange
//            IResult<int> resultInput = new ResultSuccess<int>(5);
//            // Act
//            IResult<int> result = BaseVerify.VerifyValue(resultInput, false, "Testing");
//            // Assert
//            result.Should().BeAssignableTo<IResultFailed<int>>();
//        }

//        [Fact]
//        public void VerifyValue_ShouldVerifyFailed_WhenInputFailedAndCompareSuccess()
//        {
//            // Arrange
//            IResult<int> resultInput = new ResultFailed<int>(5);
//            // Act
//            IResult<int> result = BaseVerify.VerifyValue(resultInput, true, "Testing");
//            // Assert
//            result.Should().BeAssignableTo<IResultFailed<int>>();
//        }

//        [Fact]
//        public void VerifyValue_ShouldVerifyFailed_WhenInputFailedAndCompareFailed()
//        {
//            // Arrange
//            IResult<int> resultInput = new ResultFailed<int>(5);
//            // Act
//            IResult<int> result = BaseVerify.VerifyValue(resultInput, false, "Testing");
//            // Assert
//            result.Should().BeAssignableTo<IResultFailed<int>>();
//        }


//        [Fact]
//        public void VerifyValue_ShouldOneMessageOnFailed_WhenFailed()
//        {
//            // Arrange
//            IResult<int> resultInput = new ResultFailed<int>(5);
//            resultInput.ResultMessages.Should().HaveCount(0);
//            // Act
//            IResult<int> result = BaseVerify.VerifyValue(resultInput, false, "Testing");
//            // Assert
//            result.ResultMessages.Should().HaveCount(1);
//        }
//    }
//}
