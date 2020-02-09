using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider
{
    public interface IQuestion<Answer> where Answer : IAnswer
    {
        string Text { get; }
        int Difficulty { get; }
        AnswerCollection<Answer> Answers { get; }
        double Evaluate(AnswerCollection<Answer> answers);
    }
}
