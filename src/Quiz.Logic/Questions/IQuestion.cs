namespace Quiz.Logic.Questions
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;

    public interface IQuestion
    {
        int Difficulty { get; }
    }

    public interface IQuestion<TAnswer> : IQuestion
        where TAnswer : IAnswer
    {
        double Evaluate(IEnumerable<TAnswer> deliveredAnswers);
    }
}
