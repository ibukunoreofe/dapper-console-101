using Dapper;
using DapperUsageConsole.Models;
using System.Data.SqlClient;

namespace DapperUsageConsole.Repositories
{
    public class UserRepository(string connectionString)
    {
        public async Task<int> AddUserAsync(User user)
        {
            var sql = @"INSERT INTO dbo.Users (Username, Email, CreatedDate) 
                VALUES (@Username, @Email, @CreatedDate); 
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var userId = await connection.QuerySingleAsync<int>(sql, user);
            return userId;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var sql = "SELECT * FROM dbo.Users WHERE Id = @Id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var sql = "SELECT * FROM dbo.Users";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM dbo.Users WHERE Id = @Id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }

        public async Task<bool> UpdateUserEmailAsync(int id, string newEmail)
        {
            var sql = "UPDATE dbo.Users SET Email = @Email WHERE Id = @Id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var affectedRows = await connection.ExecuteAsync(sql, new { Id = id, Email = newEmail });
            return affectedRows > 0;
        }

    }
}
