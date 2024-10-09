using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace PaymentsSystem.Database.Connection
{
    public class DatabaseConnection
    {
        private readonly string? _connectionString;

        // Construtor que recebe a string de conexão do appsettings.json
        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("paysystem");
        }

        // Método para abrir a conexão
        public MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
