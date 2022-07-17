//using ConsoleExtension.Library.Result;
//using FluentAssertions;

//namespace ConsoleExtension.Tests.System.Result
//{
//    public class ResultTests
//    {

//        [Fact]
//        public void ResultMessages_ShouldReturnEmptyList_WhenNoMessagesIsAdded()
//        {
//            // Arrange
//            IResult<int> sut = new ResultFailed<int>(1);
//            // Act
//            // Assert
//            sut.ResultMessages.Should().BeEmpty();
//        }

//        [Fact]
//        public void ResultMessages_ShouldReturnListOfOne_WhenOneMessageIsAdded()
//        {
//            // Arrange
//            IResult<int> sut = new ResultFailed<int>(1);
//            // Act
//            sut.AddResultMessage("We are testing");
//            // Assert
//            sut.ResultMessages.Should().HaveCount(1);
//        }

//        [Fact]
//        public void ResultMessages_ShouldReturnListOfTwo_WhenTwoMessagesAreAdded()
//        {
//            // Arrange
//            IResult<int> sut = new ResultFailed<int>(1);
//            // Act
//            sut.AddResultMessage("We are testing");
//            sut.AddResultMessage("We are testing... again");
//            // Assert
//            sut.ResultMessages.Should().HaveCount(2);
//        }


//        //[Fact]
//        //public void ConvertToFail_ShouldReturnNewResultFailed_WhenInputResultSuccess()
//        //{
//        //    // Arrange
//        //    IResult<int> sut = new ResultSuccess<int>(1);
//        //    // Act
//        //    IResult<int> newResult = sut.ConvertToFail();
//        //    // Assert
//        //    newResult.Should().BeAssignableTo<IResultFailed<int>>();
//        //}


//        //[Fact]
//        //public void ConvertToFail_ShouldReturnSameResultFailed_WhenInputResultFailed()
//        //{
//        //    // Arrange
//        //    IResult<int> sut = new ResultFailed<int>(1);
//        //    // Act
//        //    IResult<int> newResult = sut.ConvertToFail();
//        //    // Assert
//        //    newResult.Should().BeSameAs(sut);
//        //}


//        //[Fact]
//        //public void ConvertToSuccess_ShouldReturnNewResultSuccess_WhenInputFailed()
//        //{
//        //    // Arrange
//        //    IResult<int> sut = new ResultFailed<int>(1);
//        //    // Act
//        //    IResult<int> newResult = sut.ConvertToSuccess();
//        //    // Assert
//        //    newResult.Should().BeAssignableTo<IResultSuccess<int>>();
//        //}


//        //[Fact]
//        //public void ConvertToSuccess_ShouldReturnSameResultSuccess_WhenInputResultSuccess()
//        //{
//        //    // Arrange
//        //    IResult<int> sut = new ResultSuccess<int>(1);
//        //    // Act
//        //    IResult<int> newResult = sut.ConvertToSuccess();
//        //    // Assert
//        //    newResult.Should().BeSameAs(sut);
//        //}
//    }
//}
