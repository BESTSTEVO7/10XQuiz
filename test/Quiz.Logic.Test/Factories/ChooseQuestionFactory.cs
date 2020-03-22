namespace Quiz.Logic.Test.Factories
{
    using System;
    using System.Collections.Generic;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;

    public static class ChooseQuestionFactory
    {
        private const string DifficultyArgumentException = "Difficulty less then 0 is not a valid value.";

        private const string AmountArgumentException = "Amount less then 1 is not a valid value.";

        internal static IChooseQuestion Create(int difficulty, int amount, TrueAnswers trueAnswers)
        {
            if (difficulty < 0)
            {
                throw new ArgumentException(DifficultyArgumentException, nameof(difficulty));
            }

            if (amount <= 0)
            {
                throw new ArgumentException(AmountArgumentException, nameof(amount));
            }

            List<IChooseAnswer> answers = new List<IChooseAnswer>();
            int flagValue = 1;
            for (int i = 0; i < amount; i++)
            {
                answers.Add(ChooseAnswerFactory.Create(trueAnswers.HasFlag((TrueAnswers)flagValue)));
                flagValue *= 2;
            }

            return new ChooseQuestion(answers.AsReadOnly(), difficulty);
        }
    }
}
