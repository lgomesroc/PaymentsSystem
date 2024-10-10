using PayPal.Api;
using dotenv.net;

namespace PaymentsSystem.Services
{
    public class PayPalService : IPaymentService
    {
        private readonly string? _clientId;
        private readonly string? _clientSecret;

        public PayPalService()
        {
            // Carregar as variáveis de ambiente do arquivo .env
            DotEnv.Load();

            // Acessar as variáveis de ambiente
            _clientId = Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID");
            _clientSecret = Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET");
        }

        public APIContext GetApiContext()
        {
            var config = new Dictionary<string, string>
            {
                { "mode", "sandbox" } // ou "live" quando estiver pronto
            };

            var accessToken = new OAuthTokenCredential(_clientId, _clientSecret, config).GetAccessToken();
            return new APIContext(accessToken);
        }

        public void ProcessPayment(string token, decimal amount)
        {
            // Implementar lógica de processamento de pagamento usando o PayPal
            Console.WriteLine("Processando pagamento via PayPal...");

            // Aqui você pode usar o GetApiContext() para obter o contexto da API e processar o pagamento
        }
    }
}
