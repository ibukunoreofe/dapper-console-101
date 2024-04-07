using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUsageConsole.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public static User GenerateRandomUser()
        {
            var random = new Random();
            var id = random.Next(1000, 9999);
            return new User
            {
                Username = $"User{id}",
                Email = $"user{id}@example.com",
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
