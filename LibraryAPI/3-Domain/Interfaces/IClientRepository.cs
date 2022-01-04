using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients();
        public Task<Client> GetClient(int id);
        public Task PutClient(Client client);
        public Task<Client> PostClient(Client client);
        public Task DeleteClient(int id);
        public bool ClientExists(int id);
    }
}
