namespace Quiz.Logic.Answers
{
    public interface IChooseAnswer : IAnswer
    {
        string Text { get; }

        bool IsCorrect { get; }
    }
}
