using ConsoleExtension.Library.Result;
using FluentAssertions;

namespace ConsoleExtension.Tests.System.Result
{
    public class ResultTests
    {

        [Fact]
        public void ResultMessages_ShouldReturnEmptyList_WhenNoMessagesIsAdded()
        {
            // Arrange
            IResult<int> sut = new ResultFailed<int>(1);
            // Act
            // Assert
            sut.ResultMessages.Should().BeEmpty();
        }

        [Fact]
        public void ResultMessages_ShouldReturnListOfOne_WhenOneMessageIsAdded()
        {
            // Arrange
            IResult<int> sut = new ResultFailed<int>(1);
            // Act
            sut.AddResultMessage("We are testing");
            // Assert
            sut.ResultMessages.Should().HaveCount(1);
        }

        [Fact]
        public void ResultMessages_ShouldReturnListOfTwo_WhenTwoMessagesAreAdded()
        {
            // Arrange
            IResult<int> sut = new ResultFailed<int>(1);
            // Act
            sut.AddResultMessage("We are testing");
            sut.AddResultMessage("We are testing... again");
            // Assert
            sut.ResultMessages.Should().HaveCount(2);
        }
    }
}
