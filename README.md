# .NET Console Application with Dapper

This project demonstrates a simple .NET 8 console application that performs CRUD operations on a SQL Server database using Dapper, a popular object-relational mapping (ORM) library for .NET. The application manages a Users table, allowing the addition, deletion, updating, and listing of user records.

## Features

- Add new random users to the database
- List all users
- Search for a user by ID
- Update a user's email by ID
- Delete a user by ID

## Prerequisites

- .NET 8 SDK
- SQL Server (Local or Remote)
- Visual Studio Code, Visual Studio, or another .NET-capable IDE

## Getting Started

### Setting Up the Database

1. Ensure SQL Server is installed and accessible.
2. Use the following SQL script to create the `Users` table in your database:

    ```sql
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL,
        Email NVARCHAR(50) NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
    );
    ```

### Configuring the Application

1. Clone the repository to your local machine.
2. Open the project in your IDE.
3. Add an `appsettings.json` file to the root of the project with the following content:

    ```json
    {
      "ConnectionStrings": {
        "MyDbConnection": "Server=myServerAddress;Database=myDataBase;User Id={UserId};Password={Password};"
      }
    }
    ```

4. Replace `myServerAddress`, `myDataBase`, `{UserId}`, and `{Password}` with your SQL Server details.

### Environment Variables

Instead of hardcoding sensitive information like database user ID and password in `appsettings.json`, it is recommended to use environment variables:

- `MyDbUser` for the database user ID
- `MyDbPassword` for the database password

Set these environment variables in your system to match your SQL Server authentication details.

## Running the Application

1. Open a terminal or command prompt.
2. Navigate to the project directory.
3. Run the application using the .NET CLI:

    ```bash
    dotnet run
    ```

4. Follow the on-screen instructions to interact with the application.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have suggestions for improvements or have identified bugs.

## License

This project is open source and available under the [GNU License](LICENSE).
