namespace Quiz.Logic.Test.Questions
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;
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
        public void Evaluate_OneTrueOneFalseAnswer_Returns100()
        {
            // Arrange
            double expected = 100;
            IChooseAnswer correctAnswer = new ChooseAnswer(string.Empty, true, Guid.NewGuid());
            IChooseAnswer falseAnswer = new ChooseAnswer(string.Empty, false, Guid.NewGuid());
            List<IChooseAnswer> answers = new List<IChooseAnswer> { correctAnswer, falseAnswer };
            IQuestion<IChooseAnswer> question = new ChooseQuestion(answers, 1);

            // Act
            var actual = question.Evaluate(answers);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
