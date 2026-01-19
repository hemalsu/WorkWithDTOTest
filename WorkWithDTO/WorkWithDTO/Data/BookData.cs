using WorkWithDTO.Model.Data;
namespace WorkWithDTO.Data
{
    public static class BookData
    {
        public static readonly List<Book> books = new()
        {
            new Book
            {
                BookID = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                IssueDate = DateTime.Now.AddDays(-30),
                ReturnDueDate = DateTime.Now.AddDays(-5)
            },
            new Book
            {
                BookID = 2,
                Title = "1984",
                Author = "George Orwell",
                IssueDate = DateTime.Now.AddDays(-20),
                ReturnDueDate = DateTime.Now.AddDays(10)
            },
            new Book
            {
                BookID = 3,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                IssueDate = DateTime.Now.AddDays(-15),
                ReturnDueDate = DateTime.Now.AddDays(-1)
            },
            new Book
            {
                BookID = 4,
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                IssueDate = DateTime.Now.AddDays(-10),
                ReturnDueDate = DateTime.Now.AddDays(15)
            },
            new Book
            {
                BookID = 5,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                IssueDate = DateTime.Now.AddDays(-25),
                ReturnDueDate = DateTime.Now.AddDays(-3)
        }
        };    
    }
}
