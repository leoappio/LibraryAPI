using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI.Context;
using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._4_Infraestructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }

        public async Task PutBook(Book book)
        {

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<Book> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;

        }


        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
