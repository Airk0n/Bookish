using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Services;

namespace Bookish.Controllers
{   
    [Route("/books")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet("")]
        public IActionResult ViewExistingBooks()
        {
            var books = _bookService.GetAllBooks();
            var viewModel = new BooksViewModel {Books = books};
            return View(viewModel);
        }
        
        [HttpGet("create")]
        public IActionResult CreateBook()
        {
            return View();
        }
        
        [HttpPost("create")]
        public IActionResult CreateBook(CreateBookEntryModel newBook)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateBook", newBook);
            }

            _bookService.CreateBook(newBook);
            return RedirectToAction("ViewExistingBooks");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}