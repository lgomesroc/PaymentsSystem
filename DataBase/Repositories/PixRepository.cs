using MySql.Data.MySqlClient;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.DataBase.Models;
using System.Data;

namespace PaymentsSystem.DataBase.Repositories
{
    public class PixRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public PixRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<PixModels>> GetAllPix()
        {
            var pixList = new List<PixModels>();

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM Pix", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var pix = new PixModels
                        {
                            Id = reader.GetInt32("Id"),
                            ChavePix = reader.GetString("ChavePix"),
                            NomeTitular = reader.GetString("NomeTitular"),
                            CriadoEmPix = reader.GetDateTime("CriadoEmPix")
                        };
                        pixList.Add(pix);
                    }
                }
            }

            return pixList;
        }

        public void AdicionarPix(PixModels pix)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Pix (ChavePix, NomeTitular, CriadoEmPix) VALUES (@ChavePix, @NomeTitular, @CriadoEmPix)";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ChavePix", pix.ChavePix);
                    command.Parameters.AddWithValue("@NomeTitular", pix.NomeTitular);
                    command.Parameters.AddWithValue("@CriadoEmPix", pix.CriadoEmPix);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
