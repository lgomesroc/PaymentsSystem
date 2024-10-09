// Arquivo: Models/PixModels.cs
namespace PaymentsSystem.DataBase.Models
{
    public class PixModels
    {
        public int Id { get; set; }
        public string? ChavePix { get; set; }
        public string? NomeTitular { get; set; }
        public DateTime CriadoEmPix { get; set; }
    }
}
