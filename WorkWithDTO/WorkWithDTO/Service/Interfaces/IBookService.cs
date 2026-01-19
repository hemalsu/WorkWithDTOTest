using Microsoft.AspNetCore.Mvc;
using WorkWithDTO.Model.DTO;
namespace WorkWithDTO.Service.interfaces
{
   public  interface IBookService
    {
        public List<BookDTO> GetAllBooks();

       

        public ActionResult AddBook(BookDTO bookDTO);

    }
}
