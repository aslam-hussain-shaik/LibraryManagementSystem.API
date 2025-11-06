using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Library> Libraries => Set<Library>();
        public DbSet<Member> Members => Set<Member>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sample Seed Data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Isbn = "9780132350884", Title = "Clean Code", Author = "Robert C. Martin" },
                new Book { Id = 2, Isbn = "9780201616224", Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas" },
                new Book { Id = 3, Isbn = "9780321125217", Title = "Domain-Driven Design", Author = "Eric Evans" }
            );

            modelBuilder.Entity<Library>().HasData(
                new Library { Id = 1, Name = "Central City Library", Address = "Main Road" },
                new Library { Id = 2, Name = "Community Library", Address = "Park Street" }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "Alice Johnson", Email = "alice@example.com" },
                new Member { Id = 2, Name = "Bob Williams", Email = "bob@example.com" }
            );

        }
    }
}
