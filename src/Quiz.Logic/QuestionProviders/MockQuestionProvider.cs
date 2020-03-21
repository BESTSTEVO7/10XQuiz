namespace Quiz.Logic.QuestionProviders
{
    using System.Collections.Generic;
    using Quiz.Logic.Answers;
    using Quiz.Logic.Questions;

    public class MockQuestionProvider : IQuestionProvider
    {
        public IQuestion GetRandomQuestion(int difficulty)
        {
            IChooseAnswer correctAnswer = new ChooseAnswer(string.Empty, true);
            IChooseAnswer falseAnser = new ChooseAnswer(string.Empty, false);
            IQuestion chooseQuestion = new ChooseQuestion(new List<IChooseAnswer> { correctAnswer, falseAnser }, difficulty);

            return chooseQuestion;
        }
    }
}
