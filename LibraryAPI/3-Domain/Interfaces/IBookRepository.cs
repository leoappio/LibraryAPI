using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task PutBook(Book book);
        public Task<Book> PostBook(Book book);
        public Task DeleteBook(int id);
        public bool BookExists(int id);
    }
}
