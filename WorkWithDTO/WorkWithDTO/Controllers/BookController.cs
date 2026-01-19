using Microsoft.AspNetCore.Mvc;
using WorkWithDTO.Service.interfaces;
using WorkWithDTO.Model.DTO;

namespace WorkWithDTO.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
   // [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BookController : ControllerBase
    {
        IBookService _bookService;
        ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DueBooks()
        {
            _logger.LogInformation("Fetching all overdue books");

            try
            {
                var books = _bookService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching overdue books");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDTO> AddBook([FromBody] BookDTO bookDTO)
        {
            _logger.LogInformation("Adding a new book");
            try
            {
                var result = _bookService.AddBook(bookDTO);

                return CreatedAtAction(nameof(AddBook), new { id = bookDTO.BookID }, result);

                //return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new book");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
