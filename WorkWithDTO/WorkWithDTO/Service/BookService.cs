using Microsoft.AspNetCore.Mvc;
using WorkWithDTO.Model.DTO;
using WorkWithDTO.Repository.Interfaces;
using WorkWithDTO.Service.interfaces;
using WorkWithDTO.Model.Data;

namespace WorkWithDTO.Service
{
    public class BookService : IBookService 
    {
        public IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<BookDTO> GetAllBooks()
        {
            var OverdueBooks = _bookRepository.GetAllBooks().Where(b => b.ReturnDueDate < DateTime.Now);
            return OverdueBooks.Select(b => new BookDTO
            {
                BookID = b.BookID,
                Title = b.Title, 
                Author = b.Author,
                IssueDate = b.IssueDate,
                DaysOverdue = (DateTime.Now - b.IssueDate).Days
            }).ToList();
        }
        

        public ActionResult AddBook(BookDTO bookDTO)
        {
            _bookRepository.AddBook(new Book
            {
                BookID = bookDTO.BookID,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                IssueDate = bookDTO.IssueDate,
                ReturnDueDate = bookDTO.IssueDate.AddDays(14) // Assuming a 14-day loan period
            });
            return new OkResult();
        }
    }
}
