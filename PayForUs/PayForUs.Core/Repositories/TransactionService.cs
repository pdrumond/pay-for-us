using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;

namespace PayForUs.Core.Repositories
{
    public class TransactionService : ITransactionService
    {
        private readonly PayforusContext _context;
        private readonly IClientRepository _clienteRepository;
        private readonly IStatusRepository _statusRepository;
        private ICardRepository _cardRepository;
        private ITransactionRepository _transactionRepository;

        public TransactionService(PayforusContext context,
                                 IClientRepository clienteRepository,
                                 IStatusRepository statusRepository,
                                 ICardRepository cardRepository,
                                 ITransactionRepository transactionRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
            _statusRepository = statusRepository;
            _cardRepository = cardRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Status> Authorize(Transaction transaction)
        {
            try
            {
                if (!_cardRepository.Any(transaction.Card.NumberCard))
                    await _cardRepository.Add(transaction.Card);

                var _status = await Task.Run(() => Check(transaction));

                Card _card = await _cardRepository.FindNumberCard(transaction.Card.NumberCard);
                transaction.CardId = _card.CardId;
                transaction.StatusId = _status.Id;
                transaction.Code = _status.Code;
                transaction.Description = _status.Code;
                await _transactionRepository.Add(transaction);


                if (_status.Id == 1) //aprovado
                    _clienteRepository.DiscountAmmount(transaction.Card, transaction);

                return _status;
            }
            catch
            {
                return _context.Status.Find(10);
            }
            
        }

        public Status Check(Transaction transaction)
        {
            var _client = _clienteRepository.FindCpf(transaction.Card.Cpf);
            var _codStatus = 1;

            if (_client == null)
            {
                _codStatus = 9; //Cliente inválido
            }
            else if (!_clienteRepository.CheckLimitCred(transaction.Card, transaction))
            {
                _codStatus = 3;
            }
            else if (transaction.Card.Password.Length < 4 || transaction.Card.Password.Length > 6)
            {
                _codStatus = 6;
            }
            else if (transaction.Amount < 0.10 )
            {
                _codStatus = 4;
            }

            Status status = _context.Status.Find(_codStatus);

            return status;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _transactionRepository.GetAll();
        }

        public int GetIdStatus(Transaction transaction)
        {
            var _client = _clienteRepository.FindCpf(transaction.Card.Cpf);
            var _codStatus = 1;

            if (_client == null)
            {
                _codStatus = 9; //Cliente inválido
            }
            else if (!_clienteRepository.CheckLimitCred(transaction.Card, transaction))
            {
                _codStatus = 3;
            }
            else if (transaction.Card.Password.Length < 4 || transaction.Card.Password.Length > 6)
            {
                _codStatus = 6;
            }
            else if (transaction.Amount < 0.10)
            {
                _codStatus = 4;
            }

            return _codStatus;
        }
    }
}
