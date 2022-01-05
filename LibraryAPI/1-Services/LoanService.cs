using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Exceptions;
using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Loan;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryAPI._1_Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IBookRepository _bookRepository;

        public LoanService(ILoanRepository loanRepository, IClientRepository clientRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _clientRepository = clientRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Loan> RealizeLoan(LoanRequest loanRequest)
        {
            Client client = await _clientRepository.GetClient(loanRequest.ClientId);
            Book book = await _bookRepository.GetBook(loanRequest.BookId);

            if (client == null)
            {
                throw new ApiException("Cliente não encontrado na base de dados");

            }
            if(book == null)
            {
                throw new ApiException("Livro não encontrado na base de dados");
            }
            else if(book.Quantity <= 0)
            {
                throw new ApiException("Não há nenhum exemplar disponível");
            }

            Loan loan = new Loan(0, loanRequest.ClientId, loanRequest.BookId);
            book.Quantity -= 1;
            await _bookRepository.PutBook(book);
            return await _loanRepository.RealizeLoan(loan);

        }

        public async Task ReturnBook(LoanRequest loan)
        {
            bool _existLoan = _loanRepository.LoanExists(loan);
            Book book = await _bookRepository.GetBook(loan.BookId);

            if (!_existLoan)
            {
                throw new ApiException("Não foi encontrado este empréstimo na base de dados!");
            }

            book.Quantity += 1;
            await _bookRepository.PutBook(book);
            await _loanRepository.DeleteLoan(loan);
            
        }
    }
}
