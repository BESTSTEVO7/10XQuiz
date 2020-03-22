namespace Quiz.Logic.Test.Factories
{
    using FluentAssertions;
    using Quiz.Logic.Answers;
    using Xunit;

    public class ChooseAnswerFactoryTest
    {
        [Fact]
        public void Create_TrueAnswer_ReturnsTrueAnswer()
        {
            // Arrange
            var isCorrect = true;

            // Act
            IChooseAnswer actual = ChooseAnswerFactory.Create(isCorrect);

            // Assert
            actual.IsCorrect.Should().Be(isCorrect);
            actual.Text.Should().Be(string.Empty);
        }

        [Fact]
        public void Create_FalseAnswer_ReturnsFalseAnswer()
        {
            // Arrange
            var isCorrect = false;

            // Act
            IChooseAnswer actual = ChooseAnswerFactory.Create(isCorrect);

            // Assert
            actual.IsCorrect.Should().Be(isCorrect);
            actual.Text.Should().Be(string.Empty);
        }
    }
}
