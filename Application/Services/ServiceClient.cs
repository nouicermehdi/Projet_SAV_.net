using Application.Interfaces.IServices;
using Application.Interfaces.Repository;
using Domain.Entities;

namespace Application.Services
{
    public class ServiceClient : IService<Client>
    {
        private readonly IGenericRepository<Client> _clientRepository;

        public ServiceClient(IGenericRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }
        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client is null.");
            }

            var clientEntity = new Client
            {
                UserName = client.UserName,
                Email = client.Email,
                Name = client.Name,
                DateNaissance = client.DateNaissance,
                Password=client.Password,

            };

            return await _clientRepository.AddAsync(clientEntity);
        }

        public async Task UpdateAsync(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client is null.");
            }

            var existingClient = await _clientRepository.GetByIdAsync(client.Id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }
            existingClient.Id = client.Id;

            existingClient.UserName = client.UserName;
            existingClient.Email = client.Email;
            existingClient.Name = client.Name;
            existingClient.DateNaissance = client.DateNaissance;
            existingClient.Password = client.Password;

            await _clientRepository.UpdateAsync(existingClient);
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }

            await _clientRepository.DeleteAsync(client);
        }

    }

}
