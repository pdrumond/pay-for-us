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
                new Status { Id = 1, Code = "Aprovado", Description = "Transa��o aprovada" },
                new Status { Id = 2, Code = "Transa��o negada", Description = "Transa��o negada" },
                new Status { Id = 3, Code = "Saldo insuficiente", Description = "Portador do cart�o n�o possui saldo" },
                new Status { Id = 4, Code = "Valor inv�lido", Description = "M�nimo de 10 centavos" },
                new Status { Id = 5, Code = "Cart�o bloqueado", Description = "O cart�o est� bloqueado" },
                new Status { Id = 6, Code = "Erro no tamanho da senha", Description = "Senha deve ter entre 4 e 6 d�tigos" },
                new Status { Id = 7, Code = "Senha inv�lida", Description = "A senha enviada � inv�lida" },
                new Status { Id = 8, Code = "Cart�o inv�lido", Description = "O cart�o deve possuir 16 d�gitos" },
                new Status { Id = 9, Code = "Cliente inv�lido", Description = "O CPF do cliente � inv�lido." },
                new Status { Id = 10, Code = "Erro na Transa��o", Description = "Erro na Transa��o" }
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
                    CardholderName = "JO�O SILVA",
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
                    CardholderName = "JO�O SILVA",
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
