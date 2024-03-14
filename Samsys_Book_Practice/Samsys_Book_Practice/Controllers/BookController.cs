using Microsoft.AspNetCore.Mvc;
using Samsys_Book_Practice.DTOs;
using Samsys_Book_Practice.Interfaces.Books;

namespace Samsys_Book_Practice.Controllers
{
    namespace Samsys_Book_Practice.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BookController : ControllerBase
        {

            private readonly IBookService _bookService;

            public BookController(IBookService bookService)
            {
                _bookService = bookService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll()
            {
                var responseBooksDTOGetAll = await _bookService.GetAll();
                return responseBooksDTOGetAll.Success == false ? BadRequest(responseBooksDTOGetAll.Message) : Ok(responseBooksDTOGetAll);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<BookDTO>> GetById(int id)
            {
                var responseBookDTOGetById = await _bookService.GetById(id);
                return responseBookDTOGetById.Success == false ? BadRequest(responseBookDTOGetById.Message) : Ok(responseBookDTOGetById);
            }

            [HttpPost]
            public async Task<ActionResult<BookPostDTO>> Create(BookPostDTO bookPostDTO)
            {
                //var responseAvailable = await _bookService.AvailabilityIsbn(bookPostDTO.Isbn);
                //var responseValid = await _bookService.ValidatePrice(bookPostDTO.Preco);
                var responseBookDTOCreated = await _bookService.Create(bookPostDTO);
                return responseBookDTOCreated.Success == false ? BadRequest(responseBookDTOCreated.Message) : Ok(responseBookDTOCreated);
            }

            [HttpPut]
            public async Task<ActionResult> Update(BookDTO bookDTO)
            {
                var responseBookDTOUpdated = await _bookService.Update(bookDTO);
                return responseBookDTOUpdated.Success == false ? BadRequest(responseBookDTOUpdated.Message) : Ok(responseBookDTOUpdated); ;
            }

            [HttpDelete]
            public async Task<ActionResult<BookDTO>> Delete(int id)
            {
                var responseBookDTODeleted = await _bookService.Delete(id);
                return responseBookDTODeleted.Success == false ? BadRequest(responseBookDTODeleted.Message) : Ok(responseBookDTODeleted);
            }
        }
    }
}
