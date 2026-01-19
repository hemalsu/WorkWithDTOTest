namespace WorkWithDTO.Model.Data
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDueDate { get; set; }

    }
}
