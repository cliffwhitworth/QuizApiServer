using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class UserQuizRepository : RepositoryBase<UserQuiz>, IUserQuizRepository
    {
        public UserQuizRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
