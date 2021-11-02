using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class CreateBookEntryModel
    {
       [Required]
       public string Title { get; set; }
       
    }
}