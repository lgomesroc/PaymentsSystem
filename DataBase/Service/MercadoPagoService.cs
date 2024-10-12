using MercadoPago.Resource.Payment;
using dotenv.net;
using MercadoPago.Config; // Para carregar variáveis de ambiente do .env

namespace PaymentsSystem.Services
{
    public class MercadoPagoService : IPaymentService
    {
        private readonly string? _accessToken;
        private readonly string? _clientId;
        private readonly string? _clientSecret;

        public MercadoPagoService()
        {
            // Carregar as variáveis de ambiente do arquivo .env
            DotEnv.Load();

            // Acessar as variáveis de ambiente do Mercado Pago
            _accessToken = Environment.GetEnvironmentVariable("MERCADO_PAGO_ACCESS_TOKEN");
            _clientId = Environment.GetEnvironmentVariable("MERCADO_PAGO_CLIENT_ID");
            _clientSecret = Environment.GetEnvironmentVariable("MERCADO_PAGO_CLIENT_SECRET");

            if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
            {
                throw new Exception("As credenciais do Mercado Pago (AccessToken, ClientId ou ClientSecret) não foram configuradas corretamente.");
            }

            // Configuração do Mercado Pago
            MercadoPagoConfig.AccessToken = _accessToken;
        }

        public void ProcessPayment(string? token, decimal amount)
        {
            // Criar uma nova instância de pagamento do Mercado Pago
            var payment = new Payment
            {
                TransactionAmount = amount,  // Valor da transação
                Token = token,               // Token gerado no frontend
                Description = "Pagamento via Mercado Pago",
                PaymentMethodId = "credit_card", // Exemplo de método de pagamento (cartão de crédito)
                Payer = new Payer
                {
                    Email = "payer_email@example.com", // Substitua pelo e-mail real do pagador
                }
            };

            try
            {
                // Tenta salvar o pagamento e verificar o status
                payment.Save();

                if (payment.Status == MercadoPago.Common.PaymentStatus.approved)
                {
                    Console.WriteLine("Pagamento via Mercado Pago processado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Erro ao processar pagamento. Status: {payment.Status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar pagamento via Mercado Pago: {ex.Message}");
            }
        }
    }
}
