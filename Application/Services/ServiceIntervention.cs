using Application.Interfaces.IServices;
using Application.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceIntervention : IService<Intervention>
    {
        private readonly IGenericRepository<Intervention> _interventionRepository;

        public ServiceIntervention(IGenericRepository<Intervention> interventionRepository)
        {
            _interventionRepository = interventionRepository;
        }

        // Récupérer toutes les interventions
        public async Task<IEnumerable<Intervention>> GetAllAsync()
        {
            return await _interventionRepository.GetAllAsync();
        }

        // Récupérer une intervention par son ID
        public async Task<Intervention> GetByIdAsync(int id)
        {
            return await _interventionRepository.GetByIdAsync(id);
        }

        // Ajouter une nouvelle intervention
        public async Task<Intervention> AddAsync(Intervention intervention)
        {
            if (intervention == null)
            {
                throw new ArgumentNullException(nameof(intervention), "Intervention is null.");
            }

            var interventionEntity = new Intervention
            {
                Description = intervention.Description,
                technicien = intervention.technicien,
                client = intervention.client,
                statut = intervention.statut,
                EstSousGarantie = intervention.EstSousGarantie,
                titre = intervention.titre,
                des = intervention.des,



            };

            return await _interventionRepository.AddAsync(interventionEntity);
        }

        // Mettre à jour une intervention existante
        public async Task UpdateAsync(Intervention intervention)
        {
            if (intervention == null)
            {
                throw new ArgumentNullException(nameof(intervention), "Intervention is null.");
            }

            var existingIntervention = await _interventionRepository.GetByIdAsync(intervention.Id);
            if (existingIntervention == null)
            {
                throw new KeyNotFoundException("Intervention not found.");
            }

            existingIntervention.Description = intervention.Description;
            existingIntervention.technicien = intervention.technicien;
            existingIntervention.client = intervention.client;
            existingIntervention.statut = intervention.statut;
            existingIntervention.des = intervention.des;


            existingIntervention.titre = intervention.titre;

            existingIntervention.EstSousGarantie = intervention.EstSousGarantie;

            await _interventionRepository.UpdateAsync(existingIntervention);
        }

        // Supprimer une intervention
        public async Task DeleteAsync(int id)
        {
            var intervention = await _interventionRepository.GetByIdAsync(id);
            if (intervention == null)
            {
                throw new KeyNotFoundException("Intervention not found.");
            }

            await _interventionRepository.DeleteAsync(intervention);
        }
    }
}
