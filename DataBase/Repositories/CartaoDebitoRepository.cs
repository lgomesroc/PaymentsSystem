using MySql.Data.MySqlClient;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.DataBase.Models;
using System.Data;

namespace PaymentsSystem.DataBase.Repositories
{
    public class CartaoDebitoRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public CartaoDebitoRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<CartaoDebitoModels>> GetAllCartoesDebito()
        {
            var cartoesDebito = new List<CartaoDebitoModels>();

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM CartaoDebito", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var cartaoDebito = new CartaoDebitoModels
                        {
                            Id = reader.GetInt32("Id"),
                            NumeroCartaoDebito = reader.GetString("NumeroCartaoDebito"),
                            NomeNoCartaoDebito = reader.GetString("NomeNoCartaoDebito"),
                            CodigoSegurancaDebito = reader.GetString("CodigoSegurancaDebito"),
                            CriadoEmDebito = reader.GetDateTime("CriadoEmDebito"),
                            DataValidadeDebito = reader.GetDateTime("DataValidadeDebito")
                        };
                        cartoesDebito.Add(cartaoDebito);
                    }
                }
            }

            return cartoesDebito;
        }

        public void AdicionarCartaoDebito(CartaoDebitoModels cartaoDebito)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO CartaoDebito (NumeroCartaoDebito, NomeNoCartaoDebito, CriadoEmDebito, DataValidadeDebito, CodigoSegurancaDebito) VALUES (@NumeroCartaoDebito, @NomeNoCartaoDebito, @CriadoEmDebito, @DataValidadeDebito, @CodigoSegurancaDebito)";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroCartaoDebito", cartaoDebito.NumeroCartaoDebito);
                    command.Parameters.AddWithValue("@NomeNoCartaoDebito", cartaoDebito.NomeNoCartaoDebito);
                    command.Parameters.AddWithValue("@CriadoEmDebito", cartaoDebito.CriadoEmDebito);
                    command.Parameters.AddWithValue("@DataValidadeDebito", cartaoDebito.DataValidadeDebito);
                    command.Parameters.AddWithValue("@CodigoSegurancaDebito", cartaoDebito.CodigoSegurancaDebito);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
