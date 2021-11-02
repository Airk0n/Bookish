using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class CreateMemberEntryModel
    {
        [Required]
        public string name { get; set; }
        
    }
}