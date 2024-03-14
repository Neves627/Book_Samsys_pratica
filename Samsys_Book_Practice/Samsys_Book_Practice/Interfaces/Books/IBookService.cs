using Samsys_Book_Practice.DTOs;

namespace Samsys_Book_Practice.Interfaces.Books
{
    public interface IBookService
    {
        Task<MessagingHelper<IEnumerable<BookDTO>>> GetAll();
        Task<MessagingHelper<BookDTO>> GetById (int id);
        Task<MessagingHelper<BookPostDTO>> Create (BookPostDTO bookPostDTO);
        Task<MessagingHelper<BookDTO>> Update(BookDTO bookDTO);
        Task<MessagingHelper<BookDTO>> Delete(int i);
        Task<MessagingHelper<bool>> ValidatePrice(decimal  price);  
    }
}   
