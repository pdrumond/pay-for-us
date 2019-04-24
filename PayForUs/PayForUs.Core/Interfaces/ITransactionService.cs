using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Models;

namespace PayForUs.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<Status> Authorize(Transaction transaction);
        Status Check(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAll();
        int GetIdStatus(Transaction transaction);
    }
}
