using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class QuizAttemptsRepository : RepositoryBase<QuizAttempts>, IQuizAttemptsRepository
    {
        public QuizAttemptsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
