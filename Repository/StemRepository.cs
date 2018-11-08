using Quizzes;
using Entities;
using Entities.Models;

namespace Repository
{
    public class StemRepository : RepositoryBase<Stem>, IStemRepository
    {
        public StemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
