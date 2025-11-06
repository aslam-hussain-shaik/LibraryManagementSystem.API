using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _dbContext;

        public LibraryRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Library>> GetAllAsync()
        {
            return await _dbContext.Libraries.ToListAsync();
        }

        public async Task<Library?> GetByIdAsync(int id)
        {
            return await _dbContext.Libraries.FindAsync(id);
        }

        public async Task<Library> AddAsync(Library library)
        {
            _dbContext.Libraries.Add(library);
            await _dbContext.SaveChangesAsync();
            return library;
        }

        public async Task UpdateAsync(Library library)
        {
            _dbContext.Libraries.Update(library);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var library = await _dbContext.Libraries.FindAsync(id);
            if (library is null) return;
            _dbContext.Libraries.Remove(library);
            await _dbContext.SaveChangesAsync();
        }
    }
}
