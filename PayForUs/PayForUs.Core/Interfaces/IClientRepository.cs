using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Models;

namespace PayForUs.Core.Interfaces
{
    public interface IClientRepository
    {
        Task Add(Client client);
        Task<IEnumerable<Client>> GetAll();
        Client FindCpf(string cpf);
        void Remove(Guid clientId);
        Task<Client> Find(Guid clientId);
        bool CheckLimitCred(Card card, Transaction transaction);
        void DiscountAmmount(Card card, Transaction transaction);
    }
}
