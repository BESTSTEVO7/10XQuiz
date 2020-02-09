using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionProvider.Questions
{
    public class FreeTextQuestion : IQuestion
    {
        public string Text => throw new NotImplementedException();

        public int Difficulty => throw new NotImplementedException();

        public IAnswerCollection Solution => throw new NotImplementedException();

        public double Eveluate(IAnswerCollection answers)
        {
            throw new NotImplementedException();
        }
    }
}
