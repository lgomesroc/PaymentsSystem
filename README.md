# PaymentsSystem

Este é um projeto de sistema de pagamento desenvolvido em C#. O objetivo é criar uma aplicação que gerencie diferentes métodos de pagamento.

## Funcionalidades Implementadas

- Criação do banco de dados `payments-db` no MySQL.
- Configuração da conexão com o banco de dados.
- Estruturação das tabelas para gerenciar diferentes tipos de pagamento (Cartão de Crédito, Cartão de Débito, Pix, Boleto).
- Implementação dos serviços para gerenciar métodos de pagamento: Cartão de Crédito, Cartão de Débito, Pix e Boleto.
- Implementação dos serviços para gerenciar métodos de pagamento: PayPal, Stripe e Google Pay.
- Implementação do padrão de design Facade para simplificar o processo de pagamento.
- Configuração do GitHub Actions e GitLab CI para integração contínua.

## Configuração do PayPal

Para usar o serviço de pagamento do PayPal, você precisa definir as seguintes variáveis de ambiente:

```bash
export PAYPAL_CLIENT_ID="SEU_CLIENT_ID_AQUI"
export PAYPAL_CLIENT_SECRET="SEU_CLIENT_SECRET_AQUI"
```

## Configuração do Stripe

Para usar o serviço de pagamento do Stripe, você deve definir a seguinte variável de ambiente:

``bash
export STRIPE_SECRET_KEY="SEU_STRIPE_SECRET_KEY_AQUI"


## Configuração do Google Pay

Para usar o serviço de pagamento do Google Pay, é necessário fornecer o caminho para o arquivo de credenciais do Google:

```csharp
var credential = GoogleCredential.FromFile("path/to/googlepay-credentials.json");
```

### Testar a Integração

Depois de configurar as variáveis de ambiente, você pode testar se o `PayPalService` está funcionando corretamente, fazendo uma chamada de teste para criar uma transação ou obter informações sobre o status.

Se você precisar de mais ajuda ou exemplos específicos, fique à vontade para perguntar!

## Changelog

- **OUT-08-2024**: Início do projeto com a criação do banco de dados e configuração da conexão.
- **OUT-08-2024**: Estruturação das tabelas para os diferentes tipos de pagamento.
- **OUT-08-2024**: Criação da conexão do banco de dados.
- **OUT-09-2024**: Implementação de serviços para Cartão de Crédito, Cartão de Débito, Pix e Boleto.
- **OUT-09-2024**: Configuração do GitHub Actions e GitLab CI.
- **OUT-10-2024**: Implementação de serviços para PayPal, Stripe e Google Pay.
- **OUT-10-2024**: Implementação do padrão de design Facade para simplificar o gerenciamento de pagamentos.

## Pacotes e Funcionalidades Instalados

Este projeto utiliza os seguintes pacotes NuGet:

- **dotenv.net (Versão 3.2.1)**: Permite carregar variáveis de ambiente a partir de um arquivo `.env`, facilitando a configuração de credenciais e configurações sensíveis.
  
- **Google.Apis (Versão 1.68.0)**: Biblioteca principal para interagir com os serviços da API do Google.
  
- **Google.Apis.Auth (Versão 1.68.0)**: Fornece autenticação para acessar os serviços do Google, incluindo suporte para credenciais OAuth2.
  
- **Google.Apis.WalletObjects.v1 (Versão 1.68.0.3557)**: API para manipulação de objetos da carteira do Google, permitindo a integração com o Google Pay.

- **Microsoft.Extensions.Configuration (Versão 8.0.0)**: Fornece uma estrutura de configuração para ler dados de configuração de diversas fontes (JSON, XML, variáveis de ambiente, etc.).
  
- **Microsoft.Extensions.Configuration.Json (Versão 8.0.1)**: Suporte para carregar configurações a partir de arquivos JSON, útil para a configuração de aplicativos .NET.
  
- **Microsoft.Extensions.DependencyInjection (Versão 8.0.1)**: Implementa o padrão de injeção de dependência, facilitando a gestão de instâncias de classes no projeto.

- **MySql.Data (Versão 9.0.0)**: Driver para conectar e interagir com bancos de dados MySQL.

- **PayPal (Versão 1.9.1)**: Biblioteca para integrar pagamentos via PayPal, incluindo funcionalidades para processar transações.

- **RabbitMQ.Client (Versão 6.8.1)**: Cliente para interagir com o RabbitMQ, permitindo a implementação de mensageria no sistema.

- **Stripe.net (Versão 46.2.0)**: Biblioteca para integrar pagamentos via Stripe, com funcionalidades para processar cobranças e gerenciar transações.


## Como Executar

1. Clone o repositório.
2. Certifique-se de que o MySQL está instalado e configurado.
3. Configure o arquivo `appsettings.json` com suas credenciais do banco de dados.
4. Execute o projeto usando `dotnet run`.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

### Principais Atualizações
- **Adição dos serviços de pagamento**: O PayPal, Stripe e Google Pay foram implementados.
- **Implementação do padrão Facade**: Facilita o gerenciamento dos métodos de pagamento.
- **Novas configurações**: Instruções para configurar o Stripe e Google Pay.

# Autor

    Luciano Rocha - lgomesroc2012@gmail.com