using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options) { }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sample Seed Data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Isbn = "9780132350884", Title = "Clean Code", Author = "Robert C. Martin" },
                new Book { Id = 2, Isbn = "9780201616224", Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas" },
                new Book { Id = 3, Isbn = "9780321125217", Title = "Domain-Driven Design", Author = "Eric Evans" }
            );
        }
    }
}
