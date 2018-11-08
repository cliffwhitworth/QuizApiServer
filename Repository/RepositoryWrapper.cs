using Quizzes;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IQuizRepository _quiz;
        private IStemRepository _stem;
        private IOptionRepository _option;
        private IUsersRepository _users;
        private IUserQuizRepository _userquiz;
        private IQuizAttemptsRepository _quizattempts;

        public IQuizAttemptsRepository QuizAttempts
        {
            get
            {
                if (_quizattempts == null)
                {
                    _quizattempts = new QuizAttemptsRepository(_repoContext);
                }

                return _quizattempts;
            }
        }

        public IUserQuizRepository UserQuiz
        {
            get
            {
                if (_userquiz == null)
                {
                    _userquiz = new UserQuizRepository(_repoContext);
                }

                return _userquiz;
            }
        }

        public IUsersRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UsersRepository(_repoContext);
                }

                return _users;
            }
        }

        public IQuizRepository Quiz
        {
            get
            {
                if (_quiz == null)
                {
                    _quiz = new QuizRepository(_repoContext);
                }

                return _quiz;
            }
        }

        public IStemRepository Stem
        {
            get
            {
                if (_stem == null)
                {
                    _stem = new StemRepository(_repoContext);
                }

                return _stem;
            }
        }

        public IOptionRepository Option
        {
            get
            {
                if (_option == null)
                {
                    _option = new OptionRepository(_repoContext);
                }

                return _option;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
