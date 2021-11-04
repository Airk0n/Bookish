using System;
using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class UpdateBookModel
    {
        [Required]
        public int id { get; set; }
        
        public string Title { get; set; }
        
        public int Year { get; set; }
        
        public string Author { get; set; }

        public string Genre { get; set; }
        
        
    }
}