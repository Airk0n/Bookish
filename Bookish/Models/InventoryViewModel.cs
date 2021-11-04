using System.Collections.Generic;

namespace Bookish.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<InventoryModel> Inventory { get; set; }
    }
}