namespace Quiz.Logic.Test.Factories
{
    using System;

    [Flags]
    internal enum TrueAnswers
    {
        None = 0,
        FirstAnswer = 1,
        SecondAnser = 2,
        ThirdAnswer = 4,
        FourthAnswer = 8,
        FifthAnswer = 16,
    }
}
