// Arquivo: Services/PixService.cs
using PaymentsSystem.DataBase.Models;
using PaymentsSystem.DataBase.Repositories;

namespace PaymentsSystem.DataBase.Services
{
    public class PixService
    {
        private readonly PixRepository _pixRepository;

        public PixService(PixRepository pixRepository)
        {
            _pixRepository = pixRepository;
        }

        public void AdicionarPix(PixModels pix)
        {
            // Lógica adicional pode ser adicionada aqui (como validações)
            _pixRepository.AdicionarPix(pix);
        }
    }
}
