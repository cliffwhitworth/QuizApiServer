using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OptionRepository : RepositoryBase<Option>, IOptionRepository
    {
        public OptionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}