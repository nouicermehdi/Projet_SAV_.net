using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSAV.API.Controllers

    {
        [Route("api/[controller]")]
        [ApiController]
        public class InterventionController : ControllerBase
        {
            private readonly IService<Intervention> _serviceIntervention;

            public InterventionController(IService<Intervention> serviceIntervention)
            {
                _serviceIntervention = serviceIntervention;
            }

            // Récupérer toutes les interventions
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var interventions = await _serviceIntervention.GetAllAsync();
                return Ok(interventions);
            }

            // Récupérer une intervention par son ID
            [HttpGet("{IdIntervention}")]
            public async Task<IActionResult> GetById(int IdIntervention)
            {
                var intervention = await _serviceIntervention.GetByIdAsync(IdIntervention);
                if (intervention == null)
                {
                    return NotFound();
                }
                return Ok(intervention);
            }

            // Ajouter une nouvelle intervention
            [HttpPost]
            public async Task<IActionResult> Post([FromBody] Intervention intervention)
            {
                if (intervention == null)
                {
                    return BadRequest("Intervention is null.");
                }

                var createdIntervention = await _serviceIntervention.AddAsync(intervention);
                return CreatedAtAction(nameof(GetById), new { IdIntervention = createdIntervention.Id }, createdIntervention);
            }

            // Mettre à jour une intervention existante
            [HttpPut("{IdIntervention}")]
            public async Task<IActionResult> Put(int IdIntervention, [FromBody] Intervention intervention)
            {
                if (intervention == null || intervention.Id != IdIntervention)
                {
                    return BadRequest("Intervention is null or ID mismatch.");
                }

                var existingIntervention = await _serviceIntervention.GetByIdAsync(IdIntervention);
                if (existingIntervention == null)
                {
                    return NotFound();
                }

                await _serviceIntervention.UpdateAsync(intervention);
                return NoContent();
            }

            // Supprimer une intervention
            [HttpDelete("{IdIntervention}")]
            public async Task<IActionResult> Delete(int IdIntervention)
            {
                var intervention = await _serviceIntervention.GetByIdAsync(IdIntervention);
                if (intervention == null)
                {
                    return NotFound();
                }

                await _serviceIntervention.DeleteAsync(IdIntervention);
                return NoContent();
            }
        }
    }
