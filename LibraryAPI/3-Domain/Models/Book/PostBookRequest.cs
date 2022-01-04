using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Models.Book
{
    public class PostBookRequest
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
    }
}
