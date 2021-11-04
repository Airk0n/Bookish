using System;

namespace Bookish.Models.Database
{
    public class Book
    {
        public int id { get; set; }
        public string Title{ get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        
    }
}