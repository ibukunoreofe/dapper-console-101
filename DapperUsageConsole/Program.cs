using DapperUsageConsole.Repositories;
using Microsoft.Extensions.Configuration;

namespace DapperUsageConsole
{
    class Program
    {
        static async Task Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("MyDbConnection")!;

            var userRepository = new UserRepository(connectionString);


            await ListAllUsersAsync(userRepository);



            //// Example user ID to search for
            //int userIdToFind = 13; // You can change this to test different IDs

            //// Search and display user
            //await SearchAndDisplayUser(userRepository, userIdToFind);



            //// Example user ID to delete
            //int userIdToDelete = 5; // Change this ID based on your data

            //// Delete user and display result
            //await DeleteUserAndDisplayResult(userRepository, userIdToDelete);



            //// Generate a new random user
            //var newUser = User.GenerateRandomUser();

            //// Add the new user to the database and get their ID
            //var userId = await userRepository.AddUserAsync(newUser);
            //Console.WriteLine($"Added new user with ID: {userId}");

            //// Optionally, retrieve and display the newly added user's details
            //var addedUser = await userRepository.GetUserAsync(userId);
            //if (addedUser != null)
            //{
            //    Console.WriteLine($"New User Details: ID: {addedUser.Id}, Username: {addedUser.Username}, Email: {addedUser.Email}, CreatedDate: {addedUser.CreatedDate}");
            //}



            //// Example user ID and new email to update
            //int userIdToUpdate = 1; // Specify the user ID you want to update
            //string newUserEmail = "newemail@example.com"; // Specify the new email

            //// Update user email and display result
            //await UpdateUserEmailAndDisplayResult(userRepository, userIdToUpdate, newUserEmail);

        }

        private static async Task ListAllUsersAsync(UserRepository userRepository)
        {
            // Call GetAllUsersAsync and write output to console
            var users = await userRepository.GetAllUsersAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}, CreatedDate: {user.CreatedDate}");
            }
        }

        private static async Task SearchAndDisplayUser(UserRepository userRepository, int userId)
        {
            var user = await userRepository.GetUserAsync(userId);
            if (user != null)
            {
                Console.WriteLine($"Found User: ID: {user.Id}, Username: {user.Username}, Email: {user.Email}, CreatedDate: {user.CreatedDate}");
            }
            else
            {
                Console.WriteLine($"User with ID, {userId}, not found!");
            }
        }

        private static async Task DeleteUserAndDisplayResult(UserRepository userRepository, int userId)
        {
            var userExists = await userRepository.GetUserAsync(userId);
            if (userExists != null)
            {
                var deleted = await userRepository.DeleteUserAsync(userId);
                if (deleted)
                {
                    Console.WriteLine($"User with ID: {userId} has been deleted.");
                }
                else
                {
                    // This block might not be reached since we already check if the user exists.
                    Console.WriteLine("An error occurred while trying to delete the user.");
                }
            }
            else
            {
                Console.WriteLine($"User with ID: {userId} was not found.");
            }
        }

        static async Task UpdateUserEmailAndDisplayResult(UserRepository userRepository, int userId, string newEmail)
        {
            var userExists = await userRepository.GetUserAsync(userId);
            if (userExists != null)
            {
                var updated = await userRepository.UpdateUserEmailAsync(userId, newEmail);
                if (updated)
                {
                    Console.WriteLine($"User with ID: {userId}'s email has been updated to {newEmail}.");
                    // Optionally, display the updated user details
                    var updatedUser = await userRepository.GetUserAsync(userId);
                    Console.WriteLine($"Updated User Details: ID: {updatedUser!.Id}, Username: {updatedUser.Username}, Email: {updatedUser.Email}, CreatedDate: {updatedUser.CreatedDate}");
                }
                else
                {
                    Console.WriteLine("An error occurred while trying to update the user.");
                }
            }
            else
            {
                Console.WriteLine($"User with ID: {userId} was not found.");
            }
        }
    }
}
