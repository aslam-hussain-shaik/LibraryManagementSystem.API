using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryDbContext _dbContext;

        public MemberRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Member>> GetAllAsync() =>
            await _dbContext.Members.ToListAsync();

        public async Task<Member?> GetByIdAsync(int id) =>
            await _dbContext.Members.FindAsync(id);

        public async Task<Member> AddAsync(Member member)
        {
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();
            return member;
        }

        public async Task UpdateAsync(Member member)
        {
            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _dbContext.Members.FindAsync(id);
            if (member is null) return;
            _dbContext.Members.Remove(member);
            await _dbContext.SaveChangesAsync();
        }
    }
}
