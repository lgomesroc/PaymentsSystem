using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PaymentsSystem.Database.Connection;
using PaymentsSystem.Services;
using PaymentsSystem.DataBase.Models;
using PaymentsSystem.DataBase.Services;

namespace PaymentsSystem.Programs
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
                .BuildServiceProvider();

            // Recupera os serviços via injeção de dependência
            var cartaoCreditoService = serviceProvider.GetService<CartaoCreditoService>();
            var cartaoDebitoService = serviceProvider.GetService<CartaoDebitoService>();
            var pixService = serviceProvider.GetService<PixService>();
            var boletoService = serviceProvider.GetService<BoletoService>();

            try
            {
                // Verifica se os serviços não são nulos antes de usá-los
                if (cartaoCreditoService != null)
                {
                    // Exemplo de uso para Cartão de Crédito
                    var cartaoCredito = new CartaoCreditoModels
                    {
                        NumeroCartaoCredito = "1234567812345678",
                        DataValidadeCredito = new DateTime(2025, 12, 31),
                        NomeNoCartaoCredito = "Luciano Gomes",
                        CodigoSegurancaCredito = "123",
                        CriadoEmCredito = DateTime.Now
                    };
                    cartaoCreditoService.AdicionarCartaoCredito(cartaoCredito);
                }
                else
                {
                    Console.WriteLine("Erro: Serviço de Cartão de Crédito não pôde ser resolvido.");
                }

                if (cartaoDebitoService != null)
                {
                    // Exemplo de uso para Cartão de Débito
                    var cartaoDebito = new CartaoDebitoModels
                    {
                        NumeroCartaoDebito = "9876543210987654",
                        NomeNoCartaoDebito = "Luciano Gomes",
                        CriadoEmDebito = DateTime.Now,
                        DataValidadeDebito = new DateTime(2025, 12, 31),
                        CodigoSegurancaDebito = "456"
                    };
                    cartaoDebitoService.AdicionarCartaoDebito(cartaoDebito);
                }
                else
                {
                    Console.WriteLine("Erro: Serviço de Cartão de Débito não pôde ser resolvido.");
                }

                if (pixService != null)
                {
                    // Exemplo de uso para Pix
                    var pix = new PixModels
                    {
                        ChavePix = "luciano@pix",
                        NomeTitular = "Luciano Gomes",
                        CriadoEmPix = DateTime.Now
                    };
                    pixService.AdicionarPix(pix);
                }
                else
                {
                    Console.WriteLine("Erro: Serviço de Pix não pôde ser resolvido.");
                }

                if (boletoService != null)
                {
                    // Exemplo de uso para Boleto
                    var boleto = new BoletoModels
                    {
                        NumeroBoleto = "12345678901234567890",
                        NomeDoPagador = "Luciano Gomes",
                        Valor = 100.50M,
                        DataVencimento = new DateTime(2024, 12, 31),
                        CriadoEmBoleto = DateTime.Now
                    };
                    boletoService.AdicionarBoleto(boleto);
                }
                else
                {
                    Console.WriteLine("Erro: Serviço de Boleto não pôde ser resolvido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
