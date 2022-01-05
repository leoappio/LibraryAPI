using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Context;
using LibraryAPI.Entities;
using LibraryAPI._3_Domain.Interfaces;
using LibraryAPI._3_Domain.Models.Book;

namespace LibraryAPI._2_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBookService _bookService;

        public BooksController(AppDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await _bookService.PutBook(id, book);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(PostBookRequest bookRequest)
        {
            return Ok(await _bookService.PostBook(bookRequest));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
