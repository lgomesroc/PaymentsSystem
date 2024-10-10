using PaymentsSystem.Services; // Certifique-se de que esse namespace está correto
using System;

namespace PaymentsSystem.DesignPatterns // Ajuste o namespace conforme necessário
{
    public class FacadeDesignPatterns
    {
        private readonly PayPalService _payPalService;
        private readonly StripeService _stripeService;
        private readonly GooglePayService _googlePayService;

        public FacadeDesignPatterns(PayPalService payPalService, StripeService stripeService, GooglePayService googlePayService)
        {
            _payPalService = payPalService;
            _stripeService = stripeService;
            _googlePayService = googlePayService;
        }

        public void ProcessPayment(string paymentMethod, string token, decimal amount)
        {
            switch (paymentMethod.ToLower())
            {
                case "paypal":
                    _payPalService.ProcessPayment(token, amount);
                    break;
                case "stripe":
                    _stripeService.ProcessPayment(token, amount);
                    break;
                case "googlepay":
                    _googlePayService.ProcessPayment(token, amount);
                    break;
                default:
                    throw new NotSupportedException("Método de pagamento não suportado.");
            }
        }
    }
}
