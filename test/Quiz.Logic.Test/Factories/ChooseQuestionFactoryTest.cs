namespace Quiz.Logic.Test.Factories
{
    using FluentAssertions;
    using Quiz.Logic.Questions;
    using Xunit;

    public class ChooseQuestionFactoryTest
    {
        [Fact]
        public void Create_OneQuestionTrue_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 1, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(1);
            actual.Answers[0].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_OneQuestionFalse_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.None;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 1, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(1);
            actual.Answers[0].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondFalse_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 2, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(2);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstFalseSecondTrue_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.SecondAnser;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 2, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(2);
            actual.Answers[0].IsCorrect.Should().BeFalse();
            actual.Answers[1].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_FirstTrueSecondFalseThirdFalse_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 3, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(3);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeFalse();
            actual.Answers[2].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondTrueThirdFalse_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnser;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 3, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(3);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeTrue();
            actual.Answers[2].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondTrueThirdTrue_ReturnsQuestion()
        {
            // Arrange
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnser | TrueAnswers.ThirdAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, 3, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(3);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeTrue();
            actual.Answers[2].IsCorrect.Should().BeTrue();
        }
    }
}
