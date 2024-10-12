namespace PaymentsSystem.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(string? token, decimal amount);
    }
}
