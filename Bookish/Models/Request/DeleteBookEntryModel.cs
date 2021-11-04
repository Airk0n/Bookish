using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class DeleteBookEntryModel
    {
        [Required]
        public int id { get; set; }
    }
}