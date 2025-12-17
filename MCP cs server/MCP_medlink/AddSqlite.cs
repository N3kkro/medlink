using System;
using Microsoft.Data.Sqlite;
namespace MCP_medlink;

public class AddSqlite
{
    static void SaveComplaint(int userId, string message)
{
    using var connection = new SqliteConnection("Data Source=medlink.db");
    connection.Open();

    var cmd = connection.CreateCommand();
    cmd.CommandText = """
        INSERT INTO Complaints (UserId, Message, CreatedAt)
        VALUES ($userId, $message, $createdAt)
    """;

    cmd.Parameters.AddWithValue("$userId", userId);
    cmd.Parameters.AddWithValue("$message", message);
    cmd.Parameters.AddWithValue("$createdAt", DateTime.UtcNow.ToString("o"));

    cmd.ExecuteNonQuery();
}
}
