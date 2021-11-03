using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class UpdateMemberModel
    {
        [Required]
        public int id { get; set; }
        
        public string name { get; set; }
    }
}