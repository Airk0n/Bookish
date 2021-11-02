using System.Collections.Generic;
using Bookish.Models.Database;

namespace Bookish.Models
{
    public class BooksViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}