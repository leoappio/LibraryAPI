using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Models.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface ILoanRepository
    {
        public Task<Loan> RealizeLoan(Loan loan);
        public IEnumerable<Loan> GetAllLoansByClientId(int clientId);
        public bool LoanExists(LoanRequest loan);
        public Task DeleteLoan(LoanRequest loanRequest);
    }
}
