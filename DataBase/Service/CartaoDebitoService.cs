using PaymentsSystem.DataBase.Models;
using PaymentsSystem.DataBase.Repositories;

namespace PaymentsSystem.Services
{
    public class CartaoDebitoService
    {
        private readonly CartaoDebitoRepository _cartaoDebitoRepository;

        public CartaoDebitoService(CartaoDebitoRepository cartaoDebitoRepository)
        {
            _cartaoDebitoRepository = cartaoDebitoRepository;
        }

        // Método para adicionar um novo cartão de débito
        public void AdicionarCartaoDebito(CartaoDebitoModels cartaoDebito)
        {
            if (cartaoDebito == null)
            {
                throw new ArgumentNullException(nameof(cartaoDebito));
            }

            // Lógica de validação do cartão de débito (opcional)
            if (string.IsNullOrEmpty(cartaoDebito.NumeroCartaoDebito))
            {
                throw new ArgumentException("O número do cartão de débito não pode estar vazio.");
            }

            // Chama o repositório para adicionar o cartão
            _cartaoDebitoRepository.AdicionarCartaoDebito(cartaoDebito);
        }

        // Método para buscar todos os cartões de débito
        public async Task<List<CartaoDebitoModels>> BuscarTodosCartoesDebito()
        {
            return await _cartaoDebitoRepository.GetAllCartoesDebito();
        }
    }
}
