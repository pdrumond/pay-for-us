using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayForUs.Core.Models;
using PayForUs.Core.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayForUs.Core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// Lista os cards da To-do list.
        /// </summary>
        /// <returns>Os cards da To-do list</returns>
        /// <response code="200">Retorna os cards da To-do list cadastrados</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public Task<IEnumerable<Card>> GetAll()
        {
            return _cardRepository.GetAll();
        }

        [HttpGet("{CardId}", Name = "Card Id")]
        [ProducesResponseType(200)]
        public IActionResult GetById(Guid CardId)
        {
            var item = _cardRepository.Find(CardId);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
