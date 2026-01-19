using Microsoft.AspNetCore.Mvc;
using WorkWithDTO.Repository.Interfaces;

namespace WorkWithDTO.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    // [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class BookControllerV2 : Controller
    {
        IBookRepository bookRepository;
        ILogger<BookControllerV2> _logger;

        public BookControllerV2(IBookRepository bookRepository, ILogger<BookControllerV2> logger)
        {
            this.bookRepository = bookRepository;
            _logger = logger;
        }
       public IActionResult GetAllBooks()
        {
            _logger.LogInformation("Fetching all books - V2");
            try
            {
                var books = bookRepository.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all books - V2");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
