using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;

namespace PayForUs.Core.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly PayforusContext _context;
        public StatusRepository(PayforusContext context)
        {
            _context = context;
        }

        List<Status> _status = new List<Status>
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
        public async Task Seed()
        {
            if (!_context.Status.Any())
            {
                _context.AddRange(_status);
                await _context.SaveChangesAsync();
            }
        }

        public void Add(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<Status> Find(int statusId)
        {
            var status = await _context.Status.FindAsync(statusId);

            return status;
        }
   
    }
}
