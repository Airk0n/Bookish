using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class SelectMemberModel
    {
        [Required]
        public int id { get; set; }
    }
}