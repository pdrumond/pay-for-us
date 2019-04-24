using Moq;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace PayForUs.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        List<Client> _clients = null;
        List<Status> _status = null;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;

            _clients = new List<Client>
            {
                new Client() { ClientId = Guid.NewGuid(), Name = "Juliano Nunes", Cpf = "111111111111", LimitCredit = 1000.00 },
                new Client() { ClientId = Guid.NewGuid(), Name = "Fernanda Torres", Cpf = "222222222222", LimitCredit = 5000.00 },
                new Client() { ClientId = Guid.NewGuid(), Name = "Fernando Pinto", Cpf = "333333333333", LimitCredit = 7000.00 },
                new Client() { ClientId = Guid.NewGuid(), Name = "Leticia Amaral", Cpf = "444444444444", LimitCredit = 9000.00 }
            };

            _status = new List<Status>
            {
                new Status { Id = 1, Code = "Aprovado", Description = "Transação aprovada" },
                new Status { Id = 2, Code = "Transação negada", Description = "Transação negada" },
                new Status { Id = 3, Code = "Saldo insuficiente", Description = "Portador do cartão não possui saldo" },
                new Status { Id = 4, Code = "Valor inválido", Description = "Mínimo de 10 centavos" },
                new Status { Id = 5, Code = "Cartão bloqueado", Description = "O cartão está bloqueado" },
                new Status { Id = 6, Code = "Erro no tamanho da senha", Description = "Senha deve ter entre 4 e 6 dítigos" },
                new Status { Id = 7, Code = "Senha inválida", Description = "A senha enviada é inválida" },
                new Status { Id = 8, Code = "Cartão inválido", Description = "O cartão deve possuir 16 dígitos" },
                new Status { Id = 9, Code = "Cliente inválido", Description = "O CPF do cliente é inválido." },
                new Status { Id = 10, Code = "Erro na Transação", Description = "Erro na Transação" }
            };
        }

        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void VerifyReturnObjStatus()
        {
            Transaction transaction = new Transaction()
            {
                Amount = 500,
                Number = 5,
                Card = new Card()
                {
                    CardholderName = "JOÃO SILVA",
                    Cpf = "345563447",
                    NumberCard = "7345635763565679",
                    ExpirationDate = "1224",
                    CardBrand = "MASTER",
                    Password = "",
                    Type = "CHIP",
                    HasPassword = false
                }
            };

            Status status = new Status()
            {
                Id = 10,
                Code = "dfhdjf",
                Description = "sfgddhgh"
            };

            Console.WriteLine("inicializando teste!");

            var mockRepo = new Mock<ITransactionService>();
            mockRepo.Setup(p => p.Authorize(transaction)).ReturnsAsync(status);

            
        }

        [Fact]
        public void VerifyReturnStatus1()
        {
            Transaction transaction = new Transaction()
            {
                Amount = 500,
                Number = 5,
                Card = new Card()
                {
                    CardholderName = "JOÃO SILVA",
                    Cpf = "345563447",
                    NumberCard = "7345635763565679",
                    ExpirationDate = "1224",
                    CardBrand = "MASTER",
                    Password = "",
                    Type = "CHIP",
                    HasPassword = false
                }
            };

            Console.WriteLine("inicializando teste!");

            var mockRepo = new Mock<ITransactionService>();
            mockRepo.Setup(p => p.GetIdStatus(transaction)).Equals(981);

            ITransactionService test = mockRepo.Object;
            output.WriteLine("Results:", test.GetIdStatus(transaction));  
        }
    }
}
