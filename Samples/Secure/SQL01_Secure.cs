using System;
using Microsoft.Data.SqlClient;

public class UserRepository
{
    public void FindUser(string email)
    {
        string connectionString =
            "Server=localhost;Database=TestDb;Integrated Security=True;TrustServerCertificate=True;";

        using var connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Users WHERE Email = @Email";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Email", email);

        connection.Open();

        using var reader = command.ExecuteReader();
    }
}
