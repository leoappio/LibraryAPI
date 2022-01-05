using LibraryAPI._3_Domain.Models.Client;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClients();
        public Task<Client> GetClient(int id);
        public Task PutClient(int id, Client client);
        public Task<Client> PostClient(PostClientRequest client);
        public Task DeleteClient(int id);
        public Task<IEnumerable<Book>> GetAllLoanBooks(int clientId);

    }
}
