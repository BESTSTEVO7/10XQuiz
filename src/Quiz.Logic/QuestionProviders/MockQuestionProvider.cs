namespace Quiz.Logic.QuestionProviders
{
    using System;
    using System.Collections.Generic;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;

    public class MockQuestionProvider : IQuestionProvider
    {
        public IQuestion GetNextQuestion(int difficulty)
        {
            IChooseAnswer correctAnswer = new ChooseAnswer(string.Empty, true, Guid.NewGuid());
            IChooseAnswer falseAnswer = new ChooseAnswer(string.Empty, false, Guid.NewGuid());
            IQuestion chooseQuestion = new ChooseQuestion(new List<IChooseAnswer> { correctAnswer, falseAnswer }, difficulty);

            return chooseQuestion;
        }
    }
}
