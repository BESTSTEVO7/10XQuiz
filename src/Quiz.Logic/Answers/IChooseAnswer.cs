namespace Quiz.Logic.Answers
{
    public interface IChooseAnswer : IAnswer
    {
        public string Text { get; }

        public bool IsCorrect { get; }
    }
}
