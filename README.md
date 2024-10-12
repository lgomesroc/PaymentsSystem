# PaymentsSystem

Este é um projeto de sistema de pagamento desenvolvido em C#. O objetivo é criar uma aplicação que gerencie diferentes métodos de pagamento.

## Funcionalidades Implementadas

- Criação do banco de dados `payments-db` no MySQL.
- Configuração da conexão com o banco de dados.
- Estruturação das tabelas para gerenciar diferentes tipos de pagamento (Cartão de Crédito, Cartão de Débito, Pix, Boleto).
- Implementação dos serviços para gerenciar métodos de pagamento: Cartão de Crédito, Cartão de Débito, Pix e Boleto.
- Implementação dos serviços para gerenciar métodos de pagamento: PayPal, Stripe, Google Pay e Mercado Pago.
- Implementação do padrão de design Facade para simplificar o processo de pagamento.
- Configuração do GitHub Actions e GitLab CI para integração contínua.

## Carteiras Digitais

### Carteiras Implementadas

1. **PayPal**
   - **Status:** Implementado
   - **Justificativa:** A implementação da API do PayPal foi concluída, permitindo o processamento de pagamentos via PayPal. As informações da API são geridas por meio de variáveis de ambiente no arquivo `.env`.

2. **Mercado Pago**
   - **Status:** Implementado
   - **Justificativa:** A integração com a API do Mercado Pago foi realizada, permitindo que pagamentos sejam processados com sucesso. As configurações necessárias, como o token de acesso, também são gerenciadas via variáveis de ambiente.

3. **Stripe**
   - **Status:** Implementado
   - **Justificativa:** A implementação da API do Stripe foi concluída, permitindo o processamento de pagamentos utilizando cartões de crédito e outros métodos disponíveis pela plataforma. O serviço foi testado e funciona conforme o esperado.

4. **Google Pay**
   - **Status:** Implementado
   - **Justificativa:** A implementação da API do Google Pay foi realizada, permitindo que pagamentos sejam processados via Google Pay. A configuração necessária, incluindo credenciais do Google, é gerida através de um arquivo de credenciais especificado no código.

### Carteiras Não Implementadas

1. **Apple Pay**
   - **Status:** Não Implementado
   - **Justificativa:** A integração com a API do Apple Pay não foi realizada devido à falta de acesso à documentação necessária e à ausência de um ambiente de teste adequado. Para implementar essa carteira, é necessário ter um dispositivo Apple e configurar a conta de desenvolvedor na Apple.

2. **Samsung Pay**
   - **Status:** Não Implementado
   - **Justificativa:** Assim como o Apple Pay, a integração com a API do Samsung Pay não foi feita devido à falta de acesso à documentação e à necessidade de dispositivos específicos para testes.

3. **Amazon Pay**
   - **Status:** Não Implementado
   - **Justificativa:** A integração com a API do Amazon Pay não foi realizada devido à ausência de informações adequadas e à necessidade de credenciais de desenvolvedor que ainda não foram obtidas.

4. **PicPay**
   - **Status:** Não Implementado
   - **Justificativa:** Necessidade de conta empresarial com CNPJ para integração.

## Carteiras para implemntar mais tarde
Venmo
Zelle
Cash App
Square
Alipay
WeChat Pay
Revolut
Nubank
Nomad
Avenue
Cielo
Rede
Moeda: Uma conta digital que oferece serviços de câmbio, investimentos e pagamentos.

PagSeguro: Uma das principais plataformas de pagamento no Brasil, oferecendo soluções para e-commerce e pagamentos presenciais.

TransferWise (agora Wise): Uma plataforma para transferências internacionais com taxas baixas e câmbio em tempo real.

Banco Inter: Um banco digital brasileiro que oferece serviços de pagamento, transferências e uma conta sem tarifas.

Sodexo Pass: Um cartão e aplicativo de benefícios que permite pagamentos em estabelecimentos que aceitam o sistema Sodexo.

Sofisa Direto: Um banco digital que oferece serviços de pagamento e investimentos, com uma interface amigável.

B3 (ex-Bolsa de Valores de São Paulo): Embora seja uma bolsa de valores, algumas de suas plataformas oferecem soluções de pagamento e negociação.
SafraPay: Uma solução de pagamento que permite a aceitação de cartões de crédito e débito, voltada para comerciantes e empreendedores.

Sicredi: Uma instituição financeira cooperativa que oferece serviços bancários, incluindo opções de pagamento e transferências. O Sicredi também possui APIs para integração de pagamentos.

PagBank: Parte do grupo PagSeguro, oferece uma conta digital com funcionalidades de pagamento, transferências e serviços financeiros, ideal para empresas e autônomos.

Juno: Uma plataforma que oferece soluções de pagamentos e emissão de boletos, com APIs que podem ser utilizadas em sistemas de e-commerce.

Alelo: Oferece soluções de benefícios como refeição, alimentação, transporte, e tem APIs que permitem a integração com sistemas de pagamento.

Ticket: Conhecida pelos antigos "ticket refeição" e "ticket alimentação", a Ticket possui uma plataforma robusta com APIs para integração de benefícios, pagamentos e outros serviços corporativos.

VR Benefícios
Mastercard
Visa
American Express (Amex)

## Configuração do PayPal

Para usar o serviço de pagamento do PayPal, você precisa definir as seguintes variáveis de ambiente:

```bash
export PAYPAL_CLIENT_ID="SEU_CLIENT_ID_AQUI"
export PAYPAL_CLIENT_SECRET="SEU_CLIENT_SECRET_AQUI"
```

## Configuração do Stripe

Para usar o serviço de pagamento do Stripe, você deve definir a seguinte variável de ambiente:

```bash
export STRIPE_SECRET_KEY="SEU_STRIPE_SECRET_KEY_AQUI"
```

## Configuração do Google Pay

Para usar o serviço de pagamento do Google Pay, é necessário fornecer o caminho para o arquivo de credenciais do Google:

```bash
var credential = GoogleCredential.FromFile("path/to/googlepay-credentials.json");
```

## Configuração do Mercado Pago

Para usar o serviço de pagamento do Mercado Pago, você deve definir a seguinte variável de ambiente:

```bash
export MERCADO_PAGO_ACCESS_TOKEN="SEU_ACCESS_TOKEN_AQUI"
export MERCADO_PAGO_CLIENT_ID="SEU_CLIENT_ID_AQUI"
export MERCADO_PAGO_CLIENT_SECRET="SEU_CLIENT_SECRET_AQUI"
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
- **OUT-11-2024**: Implementação de serviço para Mercado Pago.

## Pacotes e Funcionalidades Instalados

Este projeto utiliza os seguintes pacotes NuGet:

- **dotenv.net (Versão 3.2.1)**: Permite carregar variáveis de ambiente a partir de um arquivo `.env`, facilitando a configuração de credenciais e configurações sensíveis.
  
- **Google.Apis (Versão 1.68.0)**: Biblioteca principal para interagir com os serviços da API do Google.
  
- **Google.Apis.Auth (Versão 1.68.0)**: Fornece autenticação para acessar os serviços do Google, incluindo suporte para credenciais OAuth2.
  
- **Google.Apis.WalletObjects.v1 (Versão 1.68.0.3557)**: API para manipulação de objetos da carteira do Google, permitindo a integração com o Google Pay.

- **MercadoPago (Versão 2.4.1)**: Biblioteca para integrar pagamentos via Mercado Pago.

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
