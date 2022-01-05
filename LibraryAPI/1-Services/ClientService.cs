using LibraryAPI._3_Domain.Entities;
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
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public ClientService(IClientRepository clientRepository, ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _clientRepository = clientRepository;
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }
        public async Task<IEnumerable<Book>> GetAllLoanBooks(int clientId)
        {
            var loans = _loanRepository.GetAllLoansByClientId(clientId);
            var books = new List<Book>();
            foreach(Loan loan in loans)
            {
                books.Add(await _bookRepository.GetBook(loan.BookId));
            }
            return books;
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
