using System;
using System.Collections.Generic;
using System.Text;

namespace Quizzes
{
    public interface IRepositoryWrapper
    {
        IQuizRepository Quiz { get; }
        IStemRepository Stem { get; }
        IOptionRepository Option { get; }
        IUsersRepository Users { get; }
        IUserQuizRepository UserQuiz { get; }
        IQuizAttemptsRepository QuizAttempts { get; }
    }
}
