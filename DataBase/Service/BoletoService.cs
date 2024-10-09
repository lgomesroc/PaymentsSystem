using PaymentsSystem.DataBase.Models;
using PaymentsSystem.DataBase.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsSystem.Services
{
    public class BoletoService
    {
        private readonly BoletoRepository _boletoRepository;

        public BoletoService(BoletoRepository boletoRepository)
        {
            _boletoRepository = boletoRepository;
        }

        // Método para adicionar um novo boleto
        public void AdicionarBoleto(BoletoModels boleto)
        {
            // Aqui podem ser aplicadas regras de negócio, se necessário
            _boletoRepository.AdicionarBoleto(boleto);
        }

        // Método para obter todos os boletos
        public async Task<List<BoletoModels>> GetAllBoletosAsync()
        {
            return await _boletoRepository.GetAllBoletos();
        }

        // Exemplo de outro método que pode aplicar validações
        public bool ValidarBoleto(BoletoModels boleto)
        {
            // Verificação se o boleto é válido (exemplo simples)
            if (boleto.Valor <= 0)
            {
                return false; // Valor do boleto deve ser maior que zero
            }

            if (boleto.DataVencimento < System.DateTime.Now)
            {
                return false; // O boleto não pode estar vencido
            }

            return true;
        }
    }
}
