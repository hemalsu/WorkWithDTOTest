using System;
using Xunit;
using Moq;
using WorkWithDTO.Repository.Interfaces;
using WorkWithDTO.Service;

namespace WorkWithDTO.Test
{
    public class WorkWithDTOTest
    {
        [Fact]
        public void TestOverDueBooks()
        {
            Moq.Mock<IBookRepository> mockRepo = new Moq.Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetAllBooks()).Returns(new List<Model.Data.Book>
            {
                new Model.Data.Book { BookID = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ReturnDueDate = DateTime.Now.AddDays(-5) },
                new Model.Data.Book { BookID = 2, Title = "1984", Author = "George Orwell", ReturnDueDate = DateTime.Now.AddDays(3) },
                new Model.Data.Book { BookID = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", ReturnDueDate = DateTime.Now.AddDays(-2) }
            });

            var service = new WorkWithDTO.Service.BookService(mockRepo.Object);
            var overdueBooks = service.GetAllBooks();
            Assert.Equal(2, overdueBooks.Count);
            Assert.Equal("The Great Gatsby", overdueBooks[0].Title);
        }
        [Fact]
        public void TestAddBook()
        {
           Moq.Mock<IBookRepository> mockRepo = new Moq.Mock<IBookRepository>();
            var service = new WorkWithDTO.Service.BookService(mockRepo.Object);
            var newBookDTO = new WorkWithDTO.Model.DTO.BookDTO
            {
                BookID = 4,
                Title = "Brave New World",
                Author = "Aldous Huxley",
                IssueDate = DateTime.Now
            };
            var result = service.AddBook(newBookDTO);
            mockRepo.Verify(r => r.AddBook(It.Is<WorkWithDTO.Model.Data.Book>(b => b.Title == "Brave New World")), Times.Once);

        }
    }
}