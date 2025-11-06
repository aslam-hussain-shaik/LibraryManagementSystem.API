using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book is null) return;
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
