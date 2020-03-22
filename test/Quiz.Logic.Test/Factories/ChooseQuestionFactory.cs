namespace Quiz.Logic.Test.Factories
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;

    public static class ChooseQuestionFactory
    {
        internal static IChooseQuestion Create(int difficulty, int amount, TrueAnswers trueAnswers)
        {
            IList<IChooseAnswer> answers = new List<IChooseAnswer>();
            int flagValue = 1;
            for (int i = 0; i < amount; i++)
            {
                answers.Add(ChooseAnswerFactory.Create(trueAnswers.HasFlag((TrueAnswers)flagValue)));
                flagValue *= 2;
            }

            return new ChooseQuestion(answers, difficulty);
        }
    }
}
