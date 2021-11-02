using System.Collections.Generic;
using Bookish.Models.Database;

namespace Bookish.Models.View
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}