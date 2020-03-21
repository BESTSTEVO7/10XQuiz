namespace Quiz.Logic.Answers
{
    using System;

    public class ChooseAnswer : IChooseAnswer
    {
        public string Text { get; }

        public bool IsCorrect { get; }

        public Guid Id { get; set; }

        public ChooseAnswer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}
