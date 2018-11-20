using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizzes;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApiServer.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;
        private RepositoryContext _db;

        public QuizController(ILoggerManager logger, IRepositoryWrapper repoWrapper, RepositoryContext db)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
            _db = db;
        }

        // GET api/quiz
        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            var quizzes = _repoWrapper.Quiz.FindAll();

            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");

            return quizzes;
        }

        // GET api/quiz/user/8
        [HttpGet("user/{id}")]
        public IEnumerable<QuizSettings> GetQuizzesByUser(int id)
        {

            var quizzes =
                from quiz in _db.UserQuiz
                join setting in _db.QuizSettings on quiz.SettingsId equals setting.Id
                where quiz.UserId == id
                select new QuizSettings { QuizId = quiz.QuizId,                                          
                                          SettingsId = quiz.SettingsId,
                                          UserId = quiz.UserId,
                                          QuizName = setting.QuizName,
                                          Open = setting.Open,
                                          Close = setting.Close
                                         };
            // var quizzes = _repoWrapper.UserQuiz.FindByCondition(q => q.UserId.Equals(id));

            // Console.WriteLine("C# is cool");
            // Console.WriteLine(id);

            return quizzes;
        }

        // GET api/quiz/attempts/11
        [HttpGet("attempts/{id}")]
        public IEnumerable<QuizAttempts> GetAttemptsByUserQuizID(int id)
        {

            var attempts = _repoWrapper.QuizAttempts.FindByCondition(q => q.UserQuizId.Equals(id));

            return attempts;
        }

        // Post api/quiz/grade
        [HttpPost("grade")]
        public IActionResult PostUserQuiz([FromBody] QuizGrade request)
        {
            var attempt = new QuizAttempts
            {
                UserQuizId = request.UserQuizId,
                ScoreDate = DateTime.Now
            };
            _repoWrapper.QuizAttempts.Create(attempt);
            _repoWrapper.QuizAttempts.Save();

            return Ok(new { attempt_id = attempt.Id });
        }

        // Put api/quiz/grade
        [HttpPut("grade")]
        public IActionResult UpdateUserQuiz([FromBody] QuizGrade request)
        {
            var attempt = _repoWrapper.QuizAttempts.FindByCondition(u => u.Id.Equals(request.Id)).Single();
            attempt.QuizScore = request.QuizScore;
            attempt.QuizItems = request.QuizItems;
            _repoWrapper.QuizAttempts.Save();

            return Ok(new { attempt_id = attempt.Id });
        }

        // GET api/quiz/50
        [HttpGet("{id}")]
        public IEnumerable<Quiz> Get(int id)
        {
            var quiz = _repoWrapper.Quiz.FindByCondition(q => q.Id.Equals(id));
           
            return quiz;
        }
    }

    public class QuizGrade
    {
        public int Id { get; set; }
        public int UserQuizId { get; set; }
        public int QuizScore { get; set; }
        public int QuizItems { get; set; }
    }
}
