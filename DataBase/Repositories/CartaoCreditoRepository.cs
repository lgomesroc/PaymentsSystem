using MySql.Data.MySqlClient;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.DataBase.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PaymentsSystem.DataBase.Repositories
{
    public class CartaoCreditoRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public CartaoCreditoRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<CartaoCreditoModels>> GetAllCartoesCredito()
        {
            var cartoesCredito = new List<CartaoCreditoModels>();

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM CartaoCredito", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var cartaoCredito = new CartaoCreditoModels
                        {
                            Id = reader.GetInt32("Id"),
                            NumeroCartaoCredito = reader.GetString("NumeroCartaoCredito"),
                            DataValidadeCredito = reader.GetDateTime("DataValidadeCredito"),
                            NomeNoCartaoCredito = reader.GetString("NomeNoCartaoCredito"),
                            CodigoSegurancaCredito = reader.GetString("CodigoSegurancaCredito"),
                            CriadoEmCredito = reader.GetDateTime("CriadoEmCredito")
                        };
                        cartoesCredito.Add(cartaoCredito);
                    }
                }
            }

            return cartoesCredito;
        }

        public void AdicionarCartaoCredito(CartaoCreditoModels cartaoCredito)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO CartaoCredito (NumeroCartaoCredito, DataValidadeCredito, NomeNoCartaoCredito, CodigoSegurancaCredito, CriadoEmCredito) VALUES (@NumeroCartao, @DataValidadeCredito, @NomeNoCartaoCredito, @CodigoSegurancaCredito, @CriadoEmCredito)";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroCartao", cartaoCredito.NumeroCartaoCredito);
                    command.Parameters.AddWithValue("@DataValidadeCredito", cartaoCredito.DataValidadeCredito);
                    command.Parameters.AddWithValue("@NomeNoCartaoCredito", cartaoCredito.NomeNoCartaoCredito);
                    command.Parameters.AddWithValue("@CodigoSegurancaCredito", cartaoCredito.CodigoSegurancaCredito);
                    command.Parameters.AddWithValue("@CriadoEmCredito", cartaoCredito.CriadoEmCredito);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
