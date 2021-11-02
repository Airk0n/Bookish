namespace Bookish.Models.Database
{
    public class Book
    {
        public int ID { get; set; }
        public string Title{ get; set; }
        public int Year{ get; set; }
        public string Author{ get; set; }
        public string Publisher{ get; set; }
        public string Genre{ get; set; }
    }
}