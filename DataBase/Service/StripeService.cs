using Stripe;
using System;

namespace PaymentsSystem.Services
{
    public class StripeService : IPaymentService
    {
        private readonly string _apiKey;

        public StripeService(string apiKey)
        {
            _apiKey = apiKey;
            StripeConfiguration.ApiKey = _apiKey;
        }

        public void ProcessPayment(string token, decimal amount)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100), // Stripe utiliza centavos
                Currency = "usd",
                Description = "Pagamento via Stripe",
                Source = token,
            };

            var service = new ChargeService();
            try
            {
                var charge = service.Create(options);
                Console.WriteLine("Pagamento via Stripe processado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar pagamento com Stripe: {ex.Message}");
                throw;
            }
        }
    }
}
