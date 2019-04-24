using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;

namespace PayForUs.Core.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        /// <summary>
        /// Lista todos os status de retorno.
        /// </summary>
        /// <returns>Status</returns>
        /// <response code="200">Returna os status de retorno cadastrados</response>
        [HttpGet]
        public async Task<IEnumerable<Status>> GetStatus()
        {
            return await _statusRepository.GetAll(); 
        }

        
        
    }
}
