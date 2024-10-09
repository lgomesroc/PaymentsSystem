namespace PaymentsSystem.DataBase.Models
{
    public class BoletoModels
    {
        public int Id { get; set; }
        public string? NumeroBoleto { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? NomeDoPagador { get; set; }
        public DateTime CriadoEmBoleto { get; set; }
    }
}
