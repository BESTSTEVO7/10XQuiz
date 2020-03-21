namespace Quiz.Logic.Test.QuestionProviders
{
    using FluentAssertions;
    using Quiz.Logic.QuestionProviders;
    using Quiz.Logic.Questions;
    using Xunit;

    public class MockQuestionProviderTest
    {
        [Fact]
        public void GetRandomQuestion_DifficultyOne_ReturnsQuestion()
        {
            // Arrange
            int difficulty = 1;
            MockQuestionProvider provider = new MockQuestionProvider();

            // Act
            IQuestion actual = provider.GetNextQuestion(difficulty);

            // Assert
            actual.Difficulty.Should().Be(difficulty);
        }
    }
}
