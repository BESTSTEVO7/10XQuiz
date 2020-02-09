using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider
{
    public interface IQuestion
    {
        string Text { get; }
        int Difficulty { get; }
        IAnswerCollection Solution { get; }
        double Eveluate(IAnswerCollection answers);
    }
}
