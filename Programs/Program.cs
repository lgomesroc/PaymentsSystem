using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.Services;
using PaymentsSystem.DataBase.Services;

namespace PaymentsSystem.Programs // Altere o namespace para refletir a estrutura de pastas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuração para ler o appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Setup da Injeção de Dependência
            var serviceProvider = new ServiceCollection()
                .AddSingleton(new DatabaseConnection(configuration))
                .AddScoped<IPaymentService, CartaoCreditoService>()
                .AddScoped<IPaymentService, CartaoDebitoService>()
                .AddScoped<IPaymentService, PixService>()
                .AddScoped<IPaymentService, BoletoService>()
                .AddScoped<IPaymentService, MercadoPagoService>()  // Adiciona o MercadoPagoService
                .AddScoped<IPaymentService, PayPalService>()        // Adiciona o PayPalService
                .AddScoped<IPaymentService, StripeService>()        // Adiciona o StripeService
                .AddScoped<IPaymentService, GooglePayService>()     // Adiciona o GooglePayService
                .AddScoped<PaymentProgram>() // Adiciona o PaymentProgram
                .BuildServiceProvider();

            // Recupera o PaymentProgram via injeção de dependência
            var paymentProgram = serviceProvider.GetService<PaymentProgram>();

            // Simula a execução de diferentes pagamentos
            paymentProgram?.ExecutePayment("paypal", "seu_paypal_token", 200);      // Exemplo PayPal
            paymentProgram?.ExecutePayment("stripe", "seu_stripe_token", 150);      // Exemplo Stripe
            paymentProgram?.ExecutePayment("googlepay", "seu_google_token", 120);   // Exemplo Google Pay
            paymentProgram?.ExecutePayment("mercadopago", "seu_mercado_token", 100);// Exemplo Mercado Pago
        }
    }
    //Se tirar essa classe abaixo, dará erro.
    internal class PaymentProgram
    {
        private PayPalService? payPalService;
        private StripeService? stripeService;
        private GooglePayService? googlePayService;

        public PaymentProgram(PayPalService? payPalService, StripeService? stripeService, GooglePayService? googlePayService)
        {
            this.payPalService = payPalService;
            this.stripeService = stripeService;
            this.googlePayService = googlePayService;
        }

        internal void Execute()
        {
            throw new NotImplementedException();
        }

        internal void ExecutePayment(string v1, string v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
}
