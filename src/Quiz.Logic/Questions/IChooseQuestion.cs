namespace Quiz.Logic.Questions
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;

    public interface IChooseQuestion : IQuestion<IChooseAnswer>
    {
        IList<IChooseAnswer> Answers { get; }
    }
}
