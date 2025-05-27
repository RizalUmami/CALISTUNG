using MySql.Data.MySqlClient;

public static class DatabaseConnection
{
private static readonly string connectionString =
    "Server=localhost;" +
    "Database=db_calistung;" +
    "User ID=root;" +
    "Password=;" +
    "SSL Mode=None;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}

