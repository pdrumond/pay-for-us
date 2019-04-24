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
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Lista todos os clientes.
        /// </summary>
        /// <returns>Clientes</returns>
        /// <response code="200">Returna os clientes cadastrados</response>
        [HttpGet]
        public Task<IEnumerable<Client>> GetAll()
        {
            return _clientRepository.GetAll();
        }


        /// <summary>
        /// Consulta cliente pelo cpf.
        /// </summary>
        /// <returns>Cliente</returns>
        /// <response code="200">Returna o cliente</response>
        [HttpGet("{cpf}", Name = "GetCpf")]
        public IActionResult Find(string cpf)
        {
            var item = _clientRepository.FindCpf(cpf);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Cadastra o Cliente.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Ok</returns>
        /// <response code="201">Ok</response>
        /// <response code="400">If the item is null</response>      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _clientRepository.Add(client);

            return CreatedAtRoute("GetCpf", new { Cpf = client.Cpf }, client);
        }
    }
}
