using Microsoft.EntityFrameworkCore;
using myLibrary.API.Models;

namespace myLibrary.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Book> Books { get; set; }     
        public DbSet<Author> Authors { get; set; }     
    }
}