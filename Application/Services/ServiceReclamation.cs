using Application.Interfaces.IServices;
using Application.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceReclamation : IService<Reclamation>
    {
        private readonly IGenericRepository<Reclamation> _reclamationRepository;

        public ServiceReclamation(IGenericRepository<Reclamation> reclamationRepository)
        {
            _reclamationRepository = reclamationRepository;
        }

        public async Task<IEnumerable<Reclamation>> GetAllAsync()
        {
            return await _reclamationRepository.GetAllAsync();
        }

        public async Task<Reclamation> GetByIdAsync(int id)
        {
            return await _reclamationRepository.GetByIdAsync(id);
        }

        public async Task<Reclamation> AddAsync(Reclamation reclamation)
        {
            if (reclamation == null)
            {
                throw new ArgumentNullException(nameof(reclamation), "Reclamation is null.");
            }

            // Créer un nouvel objet Reclamation sans définir l'ID (auto-incrémenté par la base de données)
            var reclamationEntity = new Reclamation
            {
                Titre = reclamation.Titre,
                Description = reclamation.Description,
                Statut = reclamation.Statut,
                client = reclamation.client,
                produit = reclamation.produit,


            };

            // Ajouter la réclamation à la base de données
            return await _reclamationRepository.AddAsync(reclamationEntity);
        }

        public async Task UpdateAsync(Reclamation reclamation)
        {
            if (reclamation == null)
            {
                throw new ArgumentNullException(nameof(reclamation), "Reclamation is null.");
            }

            var existingReclamation = await _reclamationRepository.GetByIdAsync(reclamation.Id);
            if (existingReclamation == null)
            {
                throw new KeyNotFoundException("Reclamation not found.");
            }

            existingReclamation.Titre = reclamation.Titre;
            existingReclamation.Description = reclamation.Description;
            existingReclamation.Statut = reclamation.Statut;
            existingReclamation.client = reclamation.client;
            existingReclamation.produit    = reclamation.produit;



            await _reclamationRepository.UpdateAsync(existingReclamation);
        }

        public async Task DeleteAsync(int id)
        {
            var reclamation = await _reclamationRepository.GetByIdAsync(id);
            if (reclamation == null)
            {
                throw new KeyNotFoundException("Reclamation not found.");
            }

            await _reclamationRepository.DeleteAsync(reclamation);
        }
    }
}
