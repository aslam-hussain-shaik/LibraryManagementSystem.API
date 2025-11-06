namespace LibraryManagementSystem.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }
}
