using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayForUs.Core.Models;

namespace PayForUs.Core.Interfaces
{
    public interface ICardRepository
    {
        Task Add(Card card);
        Task<IEnumerable<Card>> GetAll();
        Card Find(Guid cardId);
        void Remove(Guid cardId); 
        void Update(Card card);
        bool Any(string numberCard);
        Task<Card> FindNumberCard(string numberCard);
    }
}
