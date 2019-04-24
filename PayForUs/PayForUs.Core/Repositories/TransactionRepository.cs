using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace PayForUs.Core.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PayforusContext _context;
        public TransactionRepository(PayforusContext context)
        {
            _context = context;
        }
        public async Task Add(Transaction transaction)
        {
            transaction.TransactionId = Guid.NewGuid();
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Transaction> FindTransactions(Guid cardId)
        {
            return _context.Transactions.Where(t => t.CardId == cardId);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public void Remove(Guid transactionId)
        {
            var entity = _context.Transactions.First(t => t.TransactionId == transactionId);
            _context.Transactions.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

    }
}
