using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [Route("/inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("")]
        public IActionResult ViewLibraryInventory()
        {
            var inventoryModels = _inventoryService.GetCurrentInventory();
            var viewModel = new InventoryViewModel {Inventory = inventoryModels};
            return View(viewModel);
        }
        
        
    }
}