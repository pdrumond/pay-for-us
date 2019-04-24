using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayForUs.Core.Models;
using PayForUs.Core.Interfaces;

namespace PayForUs.Core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Autoriza transação do Cliente.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>Ok</returns>
        /// <response code="201">Status</response>
        /// <response code="400">If the item is null</response>     
        [HttpPost]
        public Task<Status> Authorize(Transaction transaction)
        {
            var _status = _transactionService.Authorize(transaction);

            return _status;
        }

        /// <summary>
        /// Lista as transações.
        /// </summary>
        /// <returns>Transações</returns>
        /// <response code="200">Returna as transações realizadas cadastrados</response>
        [HttpGet]
        public Task<IEnumerable<Transaction>> GetAll()
        {
            return _transactionService.GetAll();
        }
    }
}