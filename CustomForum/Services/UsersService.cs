using CustomForum.Models;
using CustomForum.ViewModels.Users;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CustomForum.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int? GetUserId(LoginUserViewModel input)
        {
            string passHash = this.Hash(input.Password);

            int? userId = db.Users
                .Where(u => u.Username == input.Username && u.Password == passHash)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public void Register(RegisterUserViewModel input)
        {
            var user = new User
            {
                Username = input.Username,
                Password = input.Password,
                BirthDate = input.Birthdate,
            };

            db.Users.Add(user);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
