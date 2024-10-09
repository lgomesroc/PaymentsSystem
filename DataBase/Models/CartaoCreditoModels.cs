namespace PaymentsSystem.DataBase.Models
{
    public class CartaoCreditoModels
    {
        public int Id { get; set; }
        public string? NumeroCartaoCredito { get; set; }
        public DateTime DataValidadeCredito { get; set; }
        public string? NomeNoCartaoCredito { get; set; }
        public string? CodigoSegurancaCredito { get; set; }
        public DateTime CriadoEmCredito { get; set; }
    }
}
