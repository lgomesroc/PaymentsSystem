using PayPal.Api;
using dotenv.net;
using PayPal;

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
        public void ProcessPayment(string? token, decimal amount)
        {
            Console.WriteLine("Processando pagamento via PayPal...");

            // Obter o contexto da API do PayPal
            var apiContext = GetApiContext();

            // Configurar os detalhes da transação
            var transaction = new Transaction
            {
                amount = new Amount
                {
                    currency = "USD", // Ajuste conforme a moeda que está usando
                    total = amount.ToString("F") // Converte o valor decimal para string
                },
                description = "Pagamento via PayPal"
            };

            // Configurar o pagador usando o PayPal
            var payer = new Payer
            {
                payment_method = "paypal"
            };

            // Criar o pagamento
            var payment = new Payment
            {
                intent = "sale", // Define a intenção como 'sale' para vendas diretas
                payer = payer,
                transactions = new List<Transaction> { transaction },
                redirect_urls = new RedirectUrls
                {
                    cancel_url = "https://your-cancel-url.com",
                    return_url = "https://your-return-url.com"
                }
            };

            try
            {
                // Executa a criação do pagamento via PayPal
                var createdPayment = payment.Create(apiContext);
                Console.WriteLine("Pagamento criado com sucesso.");
                Console.WriteLine($"Status do pagamento: {createdPayment.state}");
            }
            catch (PayPalException ex)
            {
                Console.WriteLine($"Erro ao processar pagamento: {ex.Message}");
            }
        }

    }
}
