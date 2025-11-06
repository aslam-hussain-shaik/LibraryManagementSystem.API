using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll() =>
            Ok(await _bookRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            var created = await _bookRepository.AddAsync(book);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            await _bookRepository.UpdateAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
