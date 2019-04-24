# Pay For Us
Sistema que simula o processo de uma transação financeira.

## Linguagem 
ASP.CORE

## Json Format Input Transaction
{
  "amount": 50,
  "number": 2,
  "card": {
    "cardholderName": "pat",
    "cpf": "111111111111",
    "numberCard": "1111222233334444",
    "expirationDate": "1222",
    "cardBrand": "mastercad",
    "password": "133434",
    "type": "chip",
    "hasPassword": false
  }
}

## Endpoints no Swagger
https://localhost:44346/swagger
- Card
	* Lista os cards da To-do list.
	* Consulta cartão
- Cliente
	* Lista todos os clientes.
	* Cadastra o Cliente.
	* Consulta cliente pelo cpf.
- Status
	* Lista todos os status de retorno.
- Transaction
	* Lista as transações.
	* Autoriza transação do Cliente.


