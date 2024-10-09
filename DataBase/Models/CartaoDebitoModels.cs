namespace PaymentsSystem.DataBase.Models
{
    public class CartaoDebitoModels
    {
        public int Id { get; set; }
        public string? NumeroCartaoDebito { get; set; }
        public string? NomeNoCartaoDebito { get; set; }
        public DateTime CriadoEmDebito { get; set; }
        public DateTime DataValidadeDebito { get; set; }
        public string? CodigoSegurancaDebito { get; set; }
    }
}
