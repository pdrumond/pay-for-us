using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;

namespace PayForUs.Core.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PayforusContext _context;
        public ClientRepository(PayforusContext context)
        {
            _context = context;
        }

        List<Client> _clients = new List<Client>
        {
            new Client() { ClientId = Guid.NewGuid(), Name = "Juliano Nunes", Cpf = "111111111111", LimitCredit = 1000.00 },
            new Client() { ClientId = Guid.NewGuid(), Name = "Fernanda Torres", Cpf = "222222222222", LimitCredit = 5000.00 },
            new Client() { ClientId = Guid.NewGuid(), Name = "Fernando Pinto", Cpf = "333333333333", LimitCredit = 7000.00 },
            new Client() { ClientId = Guid.NewGuid(), Name = "Leticia Amaral", Cpf = "444444444444", LimitCredit = 9000.00 }
        };

        public async Task Seed()
        {
            if (!_context.Clients.Any())
            {
                _context.AddRange(_clients);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> Find(Guid clientId)
        {
            return await _context.Clients.FindAsync(clientId);
        }

        public Client FindCpf(string cpf)
        {
            return _context.Clients.FirstOrDefault(t => t.Cpf == cpf);
        }

        public async Task Add(Client client)
        {
            client.ClientId = Guid.NewGuid();
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public void Remove(Guid clientId)
        {
            var entity = _context.Clients.First(t => t.ClientId == clientId);
            _context.Clients.Remove(entity);
            _context.SaveChanges();
        }

        public bool CheckLimitCred(Card card, Transaction transaction)
        {
            var _cliente = _context.Clients.First(t => t.Cpf == card.Cpf);

            if (_cliente.LimitCredit > transaction.Amount)
                return true;

            return false;
        }

        public void DiscountAmmount(Card card, Transaction transaction)
        {
            var _cliente = _context.Clients.First(t => t.Cpf == card.Cpf);
            _cliente.LimitCredit = _cliente.LimitCredit - transaction.Amount;
            _context.Clients.Update(_cliente);
            _context.SaveChanges();
        }
    }
}
