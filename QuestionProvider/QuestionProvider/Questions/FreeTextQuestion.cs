using QuestionProvider.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider.Questions
{
    public class FreeTextQuestion : IQuestion<FreeTextAnswer>
    {
        public string Text { get; }

        public int Difficulty { get; }

        public AnswerCollection<FreeTextAnswer> Answers => throw new NotImplementedException();

        public double Evaluate(AnswerCollection<FreeTextAnswer> answers)
        {
            throw new NotImplementedException();
        }
    }
}
