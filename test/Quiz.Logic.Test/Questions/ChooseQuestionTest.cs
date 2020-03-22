namespace Quiz.Logic.Test.Questions
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;
    using Quiz.Logic.Test.Factories;
    using Xunit;

    public class ChooseQuestionTest
    {
        [Fact]
        public void Constructor_AnswersNull_ThrowsArgumentNullException()
        {
            // Arrange
            IList<IChooseAnswer>? answers = null;

            // Act
            Func<IChooseQuestion> func = () => new ChooseQuestion(answers!, 0);

            // Assert
            func.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Evaluate_FirstAnswerTrueSecondAnswerFalseCorrectAnswer_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 100;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 2, TrueAnswers.FirstAnswer);

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_FirstAnswerTrueSecondAnswerFalseIncorrectAnswer_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 0;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 2, TrueAnswers.FirstAnswer);
            question.Answers[0].IsCorrect = false;

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_FirstAnswerFalseSecondAnswerTrueCorrectAnswer_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 100;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 2, TrueAnswers.SecondAnswer);

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_FirstAnswerFalseSecondAnswerTrueIncorrectAnswer_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 0;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 2, TrueAnswers.SecondAnswer);
            question.Answers[1].IsCorrect = false;

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_OneAnswerOfThreeCorrectAnsweredCorrectly_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 100;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 3, TrueAnswers.FirstAnswer);

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_TwoAnswersOfThreeCorrectAnsweredOneCorrect_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 50;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 3, TrueAnswers.FirstAnswer | TrueAnswers.SecondAnswer);
            question.Answers[0].IsCorrect = false;

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Evaluate_TwoAnswersOfThreeCorrectAnsweredTwoCorrect_ReturnsCorrectResult()
        {
            // Arrange
            double expected = 100;
            IChooseQuestion question = ChooseQuestionFactory.Create(0, 3, TrueAnswers.FirstAnswer | TrueAnswers.SecondAnswer);

            // Act
            var actual = question.Evaluate(question.Answers);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
