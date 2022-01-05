using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Context;
using LibraryAPI.Entities;
using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Client;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController( IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return Ok(await _clientService.GetClients());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientService.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client);
            }
        }
        [HttpGet("GetAllLoanBooks/{clientId}")]
        public async Task<IEnumerable<Book>> GetAllLoanBooks(int clientId)
        {
            return await _clientService.GetAllLoanBooks(clientId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            await _clientService.PutClient(id, client);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(PostClientRequest clientRequest)
        {
            return Ok(await _clientService.PostClient(clientRequest));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClient(id);
            return NoContent();
        }

    }
}
