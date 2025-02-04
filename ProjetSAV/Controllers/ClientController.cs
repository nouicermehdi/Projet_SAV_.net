using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSAV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IService<Client> _serviceClient;

        public ClientController(IService<Client> serviceClient)
        {
            _serviceClient = serviceClient;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = await _serviceClient.GetAllAsync();
            return Ok(client);
        }

        [HttpGet("{IdClient}")]
        public async Task<IActionResult> GetById(int IdClient)
        {
            var client = await _serviceClient.GetByIdAsync(IdClient);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest("Client is null.");
            }

            var createdClient = await _serviceClient.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { IdClient = createdClient.Id }, createdClient);
        }

        [HttpPut("{IdClient}")]
        public async Task<IActionResult> Put(int IdClient, [FromBody] Client client)
        {
            if (client == null || client.Id != IdClient)
            {
                return BadRequest("Client is null or ID mismatch.");
            }

            var existingClient = await _serviceClient.GetByIdAsync(IdClient);
            if (existingClient == null)
            {
                return NotFound();
            }

            await _serviceClient.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{IdClient}")]
        public async Task<IActionResult> Delete(int IdClient)
        {
            var client = await _serviceClient.GetByIdAsync(IdClient);
            if (client == null)
            {
                return NotFound();
            }

            await _serviceClient.DeleteAsync(IdClient);
            return NoContent();
        }
    }
}