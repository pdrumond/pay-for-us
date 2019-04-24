using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Models;

namespace PayForUs.Core.Interfaces
{
    public interface IStatusRepository
    {
        void Add(Status status);
        Task<Status> Find(int statusId);
        Task<IEnumerable<Status>> GetAll();
    }
}
