using MySql.Data.MySqlClient;

public static class DatabaseConnection
{
    // Pastikan Anda menggunakan MySql.Data.dll versi 6.9.x atau Connector/NET terbaru
private static readonly string connectionString =
    "Server=localhost;" +
    "Database=db_calistung;" +
    "User ID=root;" +
    "Password=;" +
    "SSL Mode=None;";  // optional untuk lokal

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}

