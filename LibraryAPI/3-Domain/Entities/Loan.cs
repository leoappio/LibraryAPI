using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
    }
}
