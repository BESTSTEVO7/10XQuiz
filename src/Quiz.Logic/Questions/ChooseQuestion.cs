namespace Quiz.Logic.Questions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Quiz.Logic.Answers;

    public class ChooseQuestion : IChooseQuestion
    {
        private const string DeliveredAnswersAmountErrorMessage =
            "Amount of given answers does not match with amount of delivered answers.";

        private const string InvalidAnswerErrorMessage =
            "Delivered answer is not in the set of possible answers.";

        public IList<IChooseAnswer> Answers { get; }

        public int Difficulty { get; }

        public ChooseQuestion(IList<IChooseAnswer> answers, int difficulty)
        {
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
            Difficulty = difficulty;
        }

        public double Evaluate(IList<IChooseAnswer> deliveredAnswers)
        {
            if (deliveredAnswers is null)
            {
                throw new ArgumentNullException(nameof(deliveredAnswers));
            }

            if (Answers.Count != deliveredAnswers.Count)
            {
                throw new ArgumentException(DeliveredAnswersAmountErrorMessage);
            }

            int correctAnswers = 0;

            foreach (IChooseAnswer answer in deliveredAnswers)
            {
                IChooseAnswer correctAnswer = Answers.FirstOrDefault(a => a.Id == answer.Id);
                if (correctAnswer == default)
                {
                    throw new ArgumentException(InvalidAnswerErrorMessage);
                }

                // Consider replacing the comparison with override of equal method on IAnswer or IEqualityComparer<IChooseAnswer>.
                if (answer.Id == correctAnswer.Id && correctAnswer.IsCorrect == answer.IsCorrect)
                {
                    correctAnswers++;
                }
            }

            return correctAnswers / Answers.Count * 100;
        }
    }
}
