using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizzes;
using Entities;
using Entities.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace QuizApiServer.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private IConfiguration _configuration;
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public UsersController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        // GET api/users/list
        [HttpGet("list")]
        public IEnumerable<Users> Get()
        {
            var users = _repoWrapper.Users.FindAll();

            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");

            return users;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var userName = User.Identity.Name;
            return Ok($"{userName} is authenticated");
        }

        [HttpGet("info")]
        public IEnumerable<Users> GetUserInfo()
        {
            // Console.WriteLine("C# is cool");
            // Console.WriteLine(User.Identity);
            // var userName = User.Identity.Name;
            //var user = _repoWrapper.Users.FindByCondition(u => u.Name.Equals(User.Identity.Name));
            IEnumerable<Users> user = _repoWrapper.Users
            .FindByCondition(u => u.Name.Equals(User.Identity.Name))
            .Select(u => new Users { Id = u.Id, Name = u.Name, Firstname = u.Firstname, Middlename = u.Middlename, Lastname = u.Lastname});

            return user;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] TokenRequest request)
        {

            var user = _repoWrapper.Users.FindByCondition(u => u.Name.Equals(request.Username)).Any();
            if (!user)
            {
                string salt = GetSalt();

                _repoWrapper.Users.Create(new Users { Name = request.Username, Firstname = request.Firstname, Middlename = request.Middlename, Lastname = request.Lastname, Password = GetHash(request.Password + salt), Salt = salt });
                _repoWrapper.Users.Save();

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QuizAPISecurityKey@378"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("This username is already taken.");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            var u2 = _repoWrapper.Users.FindByCondition(u => u.Name.Equals(request.Username)).Single();
            var salty = GetHash(request.Password + u2.Salt);
            var user = _repoWrapper.Users.FindByCondition(u => u.Name.Equals(request.Username) && u.Password.Equals(salty)).Any();

            if (user)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QuizAPISecurityKey@378"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private static string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private static string GetSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

    }

    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
    }
}
