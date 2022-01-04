using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Client;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._1_Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }
        public async Task<Client> GetClient(int id)
        {
            return await _clientRepository.GetClient(id);
        }
        public async Task PutClient(int id, Client client)
        {
            await _clientRepository.PutClient(client);
        }
        public async Task<Client> PostClient(PostClientRequest clientRequest)
        {
            Client client = new Client(0, clientRequest.Name, clientRequest.Email);
            return await _clientRepository.PostClient(client);
        }
        public async Task DeleteClient(int id)
        {
            await _clientRepository.DeleteClient(id);
        }
    }
}
