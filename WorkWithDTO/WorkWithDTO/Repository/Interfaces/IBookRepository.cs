using WorkWithDTO.Model.DTO;
using WorkWithDTO.Model.Data;
using Microsoft.AspNetCore.Mvc;

namespace WorkWithDTO.Repository.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();

        public ActionResult AddBook(Book book);
    }
}
