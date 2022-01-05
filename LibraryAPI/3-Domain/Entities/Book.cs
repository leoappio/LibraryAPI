using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }

        public Book(int id, string title, string author, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            Quantity = quantity;
        }
    }
}
