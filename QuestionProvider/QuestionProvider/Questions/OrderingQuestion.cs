using QuestionProvider.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider.Questions
{
    public class OrderingQuestion : IQuestion<OrderingAnswer>
    {
        public string Text { get; }

        public int Difficulty { get; }

        public AnswerCollection<OrderingAnswer> Answers => throw new NotImplementedException();

        public double Evaluate(AnswerCollection<OrderingAnswer> answers)
        {
            throw new NotImplementedException();
        }
    }
}
