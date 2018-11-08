using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Stem> Stems { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserQuiz> UserQuiz { get; set; }
        public DbSet<QuizAttempts> QuizAttempts { get; set; }
    }
}
