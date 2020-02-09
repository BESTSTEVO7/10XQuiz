namespace QuestionProvider
{
    using System.Collections.Generic;

    public class AnswerCollection<Answer> where Answer : IAnswer
    {
        private readonly IReadOnlyList<Answer> _answers;

        public AnswerCollection(IReadOnlyList<Answer> answers)
        {
            _answers = answers;
        }
    }
}
