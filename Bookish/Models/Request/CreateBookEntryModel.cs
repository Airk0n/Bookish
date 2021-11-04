using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class CreateBookEntryModel
    {
       [Required]
       public string Title { get; set; }
       [Required]
       public int Year { get; set; }
       [Required]
       public string Author { get; set; }
       [Required]
       public string Genre { get; set; }
       
    }
}