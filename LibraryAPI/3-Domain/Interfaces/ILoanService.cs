using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Models.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface ILoanService
    {
        public Task<Loan> RealizeLoan(LoanRequest loan);
        public Task ReturnBook(LoanRequest loan);
    }
}
