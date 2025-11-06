using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllAsync();
        Task<Library?> GetByIdAsync(int id);
        Task<Library> AddAsync(Library library);
        Task UpdateAsync(Library library);
        Task DeleteAsync(int id);
    }
}
