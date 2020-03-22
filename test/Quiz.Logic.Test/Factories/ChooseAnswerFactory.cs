namespace Quiz.Logic.Test.Factories
{
    using System;
    using Quiz.Logic.Answers;

    public static class ChooseAnswerFactory
    {
        public static IChooseAnswer Create(bool isCorrect)
        {
            return new ChooseAnswer(string.Empty, isCorrect, Guid.NewGuid());
        }
    }
}
