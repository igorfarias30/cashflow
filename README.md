# Desafio Fluxo de Caixa

A aplicação foi feita em:

    * .NET 6
    * Postgres

## Como rodar?

Com o .NET 6 e o docker já instalado em máquina, rode o comando:

```[shell]
$: docker compose up -d
```
![postgres](images/docker_compose.png)

Após a inicialização do banco de dados, a aplicação pode ser iniciada:

![Start app](images/start_app.png)

## Features

    * Balance
    * Transactions

![Endpoints](images/endpoints_cashflow.png)

### Balance

Reponsável por dar o valor consolidado do caixa a partir de uma data. 

Exemplo de query filter:
![Alt text](images/date_filter.png)

As informações retornadas são:

    * IncomeInCents: Valor de entrada em centavos
    * OutcomeInCents: Valor de saída em centavos
    * BalanceInCents: Balanço em centavos
    * DateOfCashFlow: Dia do caixa


### Transaction

Reponsável por informar, criar, atualizar e deletar os detalhes de movimentações do caixa do dia.

