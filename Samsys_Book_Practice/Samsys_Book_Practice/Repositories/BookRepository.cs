using Microsoft.EntityFrameworkCore;
using Samsys_Book_Practice.Entity;
using Samsys_Book_Practice.Interfaces.Books;
using Samsys_Book_Practice.Models;
using System.Reflection.Metadata.Ecma335;

namespace Samsys_Book_Practice.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll() {
            return await _context.Livros.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetById (int id)
        {
            return await _context.Livros.AsNoTracking().FirstAsync(x => x.id == id);
        }

        public async Task<Book> Create(Book book)
        {
            _context.Livros.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();  
            return book;
        }

        public async Task<Book> Delete(int i)
        {
            var book = await _context.Livros.FindAsync(i);
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();

                return book;
            }
            return null;
        }

        public async Task<bool> AvailabilityIsbn(string isbn, int id)
        {
            var isbnAvailable = await _context.Livros.Where(x => x.Isbn == isbn && x.id != id).AnyAsync();

            return !isbnAvailable;
        } 

    }
}
