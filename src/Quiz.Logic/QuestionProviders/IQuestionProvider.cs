﻿namespace Quiz.Logic.QuestionProviders
{
    using Quiz.Logic.Questions;

    public interface IQuestionProvider
    {
        IQuestion GetRandomQuestion(int difficulty);
    }
}
