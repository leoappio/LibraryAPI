using LibraryAPI._3_Domain.Models.Book;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._3_Domain.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(int id);
        public Task PutBook(int id, Book book);
        public Task<Book> PostBook(PostBookRequest bookRequest);
        public Task DeleteBook(int id);
    }
}
