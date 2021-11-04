using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class SelectBookModel
    {
        [Required]
        public int id { get; set; }
    }
}