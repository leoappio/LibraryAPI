using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Models.Loan
{
    public class LoanRequest
    {
        public int ClientId { get; set; }
        public int BookId { get; set; }
    }
}
