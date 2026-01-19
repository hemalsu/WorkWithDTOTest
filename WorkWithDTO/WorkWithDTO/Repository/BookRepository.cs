using Microsoft.AspNetCore.Mvc;
using WorkWithDTO.Data;
using WorkWithDTO.Model.Data;

namespace WorkWithDTO.Repository.Interfaces
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        public BookRepository()
        {
            _books = BookData.books;
        }
        public List<Book> GetAllBooks()
        {
            return _books;
        }
        public ActionResult AddBook(Book book)
        {
            _books.Add(book);
            return new OkResult();
        }

    }
}
