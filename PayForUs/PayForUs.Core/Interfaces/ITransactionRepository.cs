using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Models;

namespace PayForUs.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task Add(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAll();
        IEnumerable<Transaction> FindTransactions(Guid cardId);
        void Remove(Guid transactionId);
        void Update(Transaction transaction);
    }
}
