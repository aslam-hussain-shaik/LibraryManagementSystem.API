using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibrariesController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _libraryRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return (await _libraryRepository.GetByIdAsync(id)) is Library lib ? Ok(lib) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Library library)
        {
            return Created(string.Empty, await _libraryRepository.AddAsync(library));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Library library)
        {
            if (id != library.Id) return BadRequest();
            await _libraryRepository.UpdateAsync(library);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libraryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
