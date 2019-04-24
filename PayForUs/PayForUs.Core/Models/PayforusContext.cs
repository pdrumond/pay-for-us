using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayForUs.Core.Models
{
    public class PayforusContext : DbContext
    {
        

        public PayforusContext(DbContextOptions<PayforusContext> options)
        : base(options)
        {
           
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Status>().HasData(
            //    new { Id = 1, Code = "Aprovado", Description = "Transação aprovada" },
            //    new { Id = 2, Code = "Transação negada", Description = "Transação negada" },
            //    new { Id = 3, Code = "Saldo insuficiente", Description = "Portador do cartão não possui saldo" },
            //    new { Id = 4, Code = "Valor inválido", Description = "Mínimo de 10 centavos" },
            //    new { Id = 5, Code = "Cartão bloqueado", Description = "O cartão está bloqueado" },
            //    new { Id = 6, Code = "Erro no tamanho da senha", Description = "Senha deve ter entre 4 e 6 dítigos" },
            //    new { Id = 7, Code = "Senha inválida", Description = "A senha enviada é inválida" },
            //    new { Id = 8, Code = "Cartão inválido", Description = "O cartão deve possuir 16 dígitos" },
            //    new { Id = 9, Code = "Cliente inválido", Description = "O cliente é inválido." },
            //    new { Id = 10, Code = "Erro na Transação", Description = "Erro na Transação" }
            //);
        }


    }

    

}
