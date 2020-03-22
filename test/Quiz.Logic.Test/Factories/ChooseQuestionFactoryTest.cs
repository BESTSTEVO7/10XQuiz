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
            int amount = 1;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_OneQuestionFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 1;
            TrueAnswers trueAnswers = TrueAnswers.None;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 2;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstFalseSecondTrue_ReturnsQuestion()
        {
            // Arrange
            int amount = 2;
            TrueAnswers trueAnswers = TrueAnswers.SecondAnser;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeFalse();
            actual.Answers[1].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_FirstTrueSecondFalseThirdFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 3;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeFalse();
            actual.Answers[2].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondTrueThirdFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 3;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnser;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeTrue();
            actual.Answers[2].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FirstTrueSecondTrueThirdTrue_ReturnsQuestion()
        {
            // Arrange
            int amount = 3;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnser | TrueAnswers.ThirdAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeTrue();
            actual.Answers[2].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_FourAnswersFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 4;
            TrueAnswers trueAnswers = TrueAnswers.None;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeFalse();
            actual.Answers[1].IsCorrect.Should().BeFalse();
            actual.Answers[2].IsCorrect.Should().BeFalse();
            actual.Answers[3].IsCorrect.Should().BeFalse();
        }

        [Fact]
        public void Create_FourAnswersTrue_ReturnsQuestion()
        {
            // Arrange
            int amount = 4;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnser | TrueAnswers.ThirdAnswer | TrueAnswers.FourthAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeTrue();
            actual.Answers[2].IsCorrect.Should().BeTrue();
            actual.Answers[3].IsCorrect.Should().BeTrue();
        }

        [Fact]
        public void Create_FirstTrueSecondFalseThirdTrueFourthFalse_ReturnsQuestion()
        {
            // Arrange
            int amount = 4;
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.ThirdAnswer;

            // Act
            IChooseQuestion actual = ChooseQuestionFactory.Create(0, amount, trueAnswers);

            // Assert
            actual.Answers.Count.Should().Be(amount);
            actual.Answers[0].IsCorrect.Should().BeTrue();
            actual.Answers[1].IsCorrect.Should().BeFalse();
            actual.Answers[2].IsCorrect.Should().BeTrue();
            actual.Answers[3].IsCorrect.Should().BeFalse();
        }
    }
}
