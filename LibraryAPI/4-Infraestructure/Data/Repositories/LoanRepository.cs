using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Loan;
using LibraryAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._4_Infraestructure.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Loan> RealizeLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
        public IEnumerable<Loan> GetAllLoansByClientId(int clientId)
        {
           return _context.Loans.Where<Loan>(loan => loan.ClientId == clientId).ToList();
        }
        public bool LoanExists(LoanRequest loan)
        {
            return _context.Loans.Any(l => l.ClientId == loan.ClientId && l.BookId == loan.BookId);
        }
        public async Task DeleteLoan(LoanRequest loanRequest)
        {
            var loan = _context.Loans.Where<Loan>(l => l.ClientId == loanRequest.ClientId && l.BookId == loanRequest.BookId).First();
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}
