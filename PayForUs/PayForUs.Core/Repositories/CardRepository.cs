using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;

namespace PayForUs.Core.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly PayforusContext _context;
        public CardRepository(PayforusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task Add(Card card)
        {
            card.CardId = Guid.NewGuid();
            card.CreatedBy = new DateTime();
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public bool Any(string numberCard)
        {
            return _context.Cards.Any(a => a.NumberCard == numberCard);
        }

        public Card Find(Guid cardId)
        {
            return _context.Cards.FirstOrDefault(t => t.CardId == cardId);
        }

        public async Task<Card> FindNumberCard(string numberCard)
        {
            return await _context.Cards.FirstOrDefaultAsync(a => a.NumberCard == numberCard);
        }        

        public void Remove(Guid cardId)
        {
            var entity = _context.Cards.First(t => t.CardId == cardId);
            _context.Cards.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Card card)
        {
            _context.Cards.Update(card);
            _context.SaveChanges();
        }
    }
}
