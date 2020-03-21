namespace Quiz.Logic.Questions
{
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
            Answers = answers;
            Difficulty = difficulty;
        }

        public double Evaluate(IList<IAnswer> deliveredAnswers)
        {
            if (Answers.Count != deliveredAnswers.Count)
            {
                throw new System.ArgumentException(DeliveredAnswersAmountErrorMessage);
            }

            int correctAnswers = 0;

            foreach (IAnswer answer in deliveredAnswers)
            {
                IAnswer correctAnswer = Answers.FirstOrDefault(a => a.Id == answer.Id);
                if (correctAnswer == default)
                {
                    throw new System.ArgumentException(InvalidAnswerErrorMessage);
                }

                correctAnswers = answer.Equals(deliveredAnswers) ? correctAnswers++ : correctAnswers;
            }

            return correctAnswers / Answers.Count;
        }
    }
}
