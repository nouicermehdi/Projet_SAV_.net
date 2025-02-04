using Application.Interfaces.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSAV.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class ReclamationController : ControllerBase
        {
            private readonly IService<Reclamation>  _serviceReclamation;

            public ReclamationController(IService<Reclamation> serviceReclamation)
            {
                _serviceReclamation = serviceReclamation;
            }


            // GET: api/reclamations
            [HttpGet]
            public async Task<IActionResult> GetAllReclamations()
            {
                var reclamations = await _serviceReclamation.GetAllAsync();
                return Ok(reclamations);
            }

            // GET: api/reclamations/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetReclamationById(int id)
            {
                var reclamation = await _serviceReclamation.GetByIdAsync(id);
                if (reclamation == null)
                {
                    return NotFound();
                }
                return Ok(reclamation);
            }

            // POST: api/reclamations
            [HttpPost]
            public async Task<IActionResult> AddReclamation([FromBody] Reclamation reclamation)
            {
                if (reclamation == null)
                {
                    return BadRequest("Invalid data.");
                }
                var addedReclamation = await _serviceReclamation.AddAsync(reclamation);
                return CreatedAtAction(nameof(GetReclamationById), new { id = addedReclamation.Id }, addedReclamation);
            }

            // PUT: api/reclamations/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateReclamation(int id, [FromBody] Reclamation reclamation)
            {
                if (reclamation == null || id != reclamation.Id)
                {
                    return BadRequest();
                }
                await _serviceReclamation.UpdateAsync(reclamation);
                return NoContent();
            }

            // DELETE: api/reclamations/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReclamation(int id)
            {
                await _serviceReclamation.DeleteAsync(id);
                return NoContent();
            }
        }
    }
