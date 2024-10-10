using Microsoft.Extensions.DependencyInjection;
using PaymentsSystem.Programs;
using PaymentsSystem.Services;

var serviceProvider = new ServiceCollection()
    .AddTransient<IPaymentService, PayPalService>() // Registrar PayPalService
    .AddTransient<IPaymentService, StripeService>() // Registrar StripeService
    .AddTransient<IPaymentService, GooglePayService>() // Registrar GooglePayService
    .BuildServiceProvider();

// Obter uma instância do PaymentProgram, injetando os serviços apropriados
var paymentProgram = new PaymentProgram(
    serviceProvider.GetServices<IPaymentService>().First(s => s is PayPalService) as PayPalService,
    serviceProvider.GetServices<IPaymentService>().First(s => s is StripeService) as StripeService,
    serviceProvider.GetServices<IPaymentService>().First(s => s is GooglePayService) as GooglePayService
);

// Executar um pagamento de exemplo
paymentProgram.ExecutePayment("stripe", "exemplo_token", 100);
