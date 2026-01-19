namespace WorkWithDTO.Model.DTO
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int DaysOverdue{ get; set; }

        public DateTime IssueDate { get; set; }
    }
}
