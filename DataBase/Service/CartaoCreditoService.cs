using PaymentsSystem.DataBase.Models;
using PaymentsSystem.DataBase.Repositories;

namespace PaymentsSystem.Services
{
    public class CartaoCreditoService
    {
        private readonly CartaoCreditoRepository _cartaoCreditoRepository;

        public CartaoCreditoService(CartaoCreditoRepository cartaoCreditoRepository)
        {
            _cartaoCreditoRepository = cartaoCreditoRepository;
        }

        // Método para adicionar um novo cartão de crédito
        public void AdicionarCartaoCredito(CartaoCreditoModels cartaoCredito)
        {
            if (cartaoCredito == null)
            {
                throw new ArgumentNullException(nameof(cartaoCredito));
            }

            // Lógica de validação do cartão de crédito (opcional)
            if (string.IsNullOrEmpty(cartaoCredito.NumeroCartaoCredito))
            {
                throw new ArgumentException("O número do cartão de crédito não pode estar vazio.");
            }

            // Chama o repositório para adicionar o cartão
            _cartaoCreditoRepository.AdicionarCartaoCredito(cartaoCredito);
        }

        // Método para buscar todos os cartões de crédito
        public async Task<List<CartaoCreditoModels>> BuscarTodosCartoesCredito()
        {
            return await _cartaoCreditoRepository.GetAllCartoesCredito();
        }
    }
}
