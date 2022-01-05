using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Book;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._1_Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }
        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetBook(id);
        }
        public async Task PutBook(int id, Book book)
        {
            await _bookRepository.PutBook(book);
        }
        public async Task<Book> PostBook(PostBookRequest bookRequest)
        {
            Book book = new Book(0, bookRequest.Title, bookRequest.Author, bookRequest.Quantity);
            return await _bookRepository.PostBook(book);
        }
        public async Task DeleteBook(int id)
        {
            await _bookRepository.DeleteBook(id);
        }

    }
}
