
using Bookish.Models.Database;

namespace Bookish.Models
{
    public class InventoryModel
    {
        public InventoryModel(Book book,int Copies, int AvailableCopies)
        {
            this.Book = book;
            this.Copies = Copies;
            this.AvailableCopies = AvailableCopies;
        }
        public Book Book { get; set; }
        public int Copies { get; set; }
        public int AvailableCopies {get; set; }
    }
}