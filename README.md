# ₿ - QualValorCrypto 

## Ideia do projeto
Crypto moedas é um assunto que vem ganhando destaque no cenário mundial, grande parte devido ao sucesso do Bitcoin e do cenário que vivemos hoje, onde essas moedas tiveram um aumento de demanda, e consequentemente um aumento de valor, já que são escassaz. 
A ideia é ter uma API onde eu possa obter informações sobre a cotação de uma cryptomoeda, e que essa API tivesse sempre com os valores atualizados e esses valores fossem atualizadas devido à um outro serviço.

## Objetivo
Praticar o uso de um repositório NoSQL, utilização de mensageria através da Rabbit e a realização de testes de integração.

O projeto é pequeno e bem simples, nesse cenário não compensaria criar muitos testes de integração devido ao custo de execução dos mesmos, o melhor seria apenas demandar esforço em testes de unidade, que também foram implementados.


## Tecnologias / Ferramentas / Práticas utilizadas
- MongoDB
- MongoDbGo - Para testes de integração
- RabbitMq
- xUnit - Teste de unidade e teste de integração
- Arquitetura dividida em camadas (API, Infra, Aplicação e Domínio)

## Observações
Foram criados dois workers que simulam serviços que atualizam o banco através da mensageria, **consumidor e produtor**, ambos se encontram no projeto 'Worker'.
