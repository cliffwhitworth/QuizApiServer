using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class QuizSettingsRepository : RepositoryBase<QuizSettings>, IQuizSettingsRepository
    {
        public QuizSettingsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
