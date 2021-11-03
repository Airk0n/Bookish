using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class RemoveMemberEntryModel
    {
        [Required]
        public int id { get; set; }
    }
}