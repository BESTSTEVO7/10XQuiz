namespace Quiz.Logic.Questions
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;

    public interface IQuestion
    {
        int Difficulty { get; }

        double Evaluate(IList<IAnswer> deliveredAnswers);
    }
}
