using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
    {
        public QuizRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}