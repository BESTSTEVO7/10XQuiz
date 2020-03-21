namespace Quiz.Logic.Questions
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;

    public interface IChooseQuestion : IQuestion
    {
        IList<IChooseAnswer> Answers { get; }
    }
}
