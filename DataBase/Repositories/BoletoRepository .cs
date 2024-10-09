using MySql.Data.MySqlClient;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.DataBase.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PaymentsSystem.DataBase.Repositories
{
    public class BoletoRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public BoletoRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<BoletoModels>> GetAllBoletos()
        {
            var boletos = new List<BoletoModels>();

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM Boleto", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var boleto = new BoletoModels
                        {
                            Id = reader.GetInt32("Id"),
                            NumeroBoleto = reader.GetString("NumeroBoleto"),
                            DataVencimento = reader.GetDateTime("DataVencimento"),
                            Valor = reader.GetDecimal("Valor"),
                            NomeDoPagador = reader.GetString("NomeDoPagador"),
                            CriadoEmBoleto = reader.GetDateTime("CriadoEmBoleto")
                        };
                        boletos.Add(boleto);
                    }
                }
            }

            return boletos;
        }

        public void AdicionarBoleto(BoletoModels boleto)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Boleto (NumeroBoleto, DataVencimento, Valor, NomeDoPagador, CriadoEmBoleto) VALUES (@NumeroBoleto, @DataVencimento, @Valor, @NomeDoPagador, @CriadoEmBoleto)";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroBoleto", boleto.NumeroBoleto);
                    command.Parameters.AddWithValue("@DataVencimento", boleto.DataVencimento);
                    command.Parameters.AddWithValue("@Valor", boleto.Valor);
                    command.Parameters.AddWithValue("@NomeDoPagador", boleto.NomeDoPagador);
                    command.Parameters.AddWithValue("@CriadoEmBoleto", boleto.CriadoEmBoleto);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
