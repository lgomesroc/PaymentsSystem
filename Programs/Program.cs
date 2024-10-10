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
                .AddScoped<CartaoCreditoService>()
                .AddScoped<CartaoDebitoService>()
                .AddScoped<PixService>()
                .AddScoped<BoletoService>()
                .AddScoped<PaymentProgram>() // Adiciona o PaymentProgram
                .BuildServiceProvider();

            // Recupera o PaymentProgram via injeção de dependência
            var paymentProgram = serviceProvider.GetService<PaymentProgram>();

            // Executa o programa de pagamento
            paymentProgram?.Execute(); // Verifica se o serviço não é nulo antes de chamar
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
