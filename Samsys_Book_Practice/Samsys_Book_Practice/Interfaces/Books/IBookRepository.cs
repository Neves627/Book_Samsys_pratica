using Samsys_Book_Practice.Entity;

namespace Samsys_Book_Practice.Interfaces.Books
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById (int id);
        Task<Book> Create (Book book);
        Task<Book> Update (Book book);
        Task<Book> Delete (int id);
        Task<bool> AvailabilityIsbn(string isbn, int id);
    }
}
