using Microsoft.EntityFrameworkCore;
using Samsys_Book_Practice.Entity;

namespace Samsys_Book_Practice.Models
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        //CRIAR A BD
        public DbSet<Book> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BookContext).Assembly);
        }
    }
}
