namespace Quiz.Logic.Questions
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;

    public interface IChooseQuestion : IQuestion<IChooseAnswer>
    {
        IReadOnlyList<IChooseAnswer> Answers { get; }

        IList<IChooseAnswer> GetAnswerOptions();
    }
}
