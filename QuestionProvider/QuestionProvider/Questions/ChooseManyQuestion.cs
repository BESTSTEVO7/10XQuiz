using QuestionProvider.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider.Questions
{
    public class ChooseManyQuestion : IQuestion<ChooseAnswer>
    {
        public string Text { get; }

        public int Difficulty { get; }

        public AnswerCollection<ChooseAnswer> Answers => throw new NotImplementedException();

        public double Evaluate(AnswerCollection<ChooseAnswer> answers)
        {
            throw new NotImplementedException();
        }
    }
}
