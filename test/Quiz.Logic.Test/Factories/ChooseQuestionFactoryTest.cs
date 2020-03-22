namespace Quiz.Logic.Test.Factories
{
    using System;
    using FluentAssertions;
    using Quiz.Logic.Questions;
    using Xunit;

    public class ChooseQuestionFactoryTest
    {
        [Fact]
        public void Create_DifficultyLessThenZero_ThrowsArgumentException()
        {
            // Arrange
            int difficulty = -1;

            // Act
            Func<IChooseQuestion> func = () => ChooseQuestionFactory.Create(difficulty, 0, TrueAnswers.None);

            // Assert
            func.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Create_AmountOfAnswersLessThenZero_ThrowsArgumentException()
        {
            // Arrange
            int amount = -1;

            // Act
            Func<IChooseQuestion> func = () => ChooseQuestionFactory.Create(0, amount, TrueAnswers.None);

            // Assert
            func.Should().ThrowExactly<ArgumentException>();
        }

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
            TrueAnswers trueAnswers = TrueAnswers.SecondAnswer;

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
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnswer;

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
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnswer | TrueAnswers.ThirdAnswer;

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
            TrueAnswers trueAnswers = TrueAnswers.FirstAnswer | TrueAnswers.SecondAnswer | TrueAnswers.ThirdAnswer | TrueAnswers.FourthAnswer;

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
