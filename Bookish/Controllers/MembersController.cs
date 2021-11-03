using System.Diagnostics;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookish.Controllers
{
    [Route("/members")]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        [HttpGet("")]
        public IActionResult ViewAvailableMembers()
        {
            var members = _memberService.GetAllMembers();
            var viewModel = new MembersViewModel {Members = members};
            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult CreateMember()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateMember(CreateMemberEntryModel newMember)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateMember", newMember);
            }
            _memberService.CreateMember(newMember);
            return RedirectToAction("ViewAvailableMembers");
        }
        
        [HttpGet("remove")]
        public IActionResult RemoveMember()
        {
            return View();
        }
        
        [HttpPost("remove")]
        public IActionResult RemoveMember(RemoveMemberEntryModel removeMember)
        {
            if (!ModelState.IsValid)
            {
                return View("RemoveMember", removeMember);
            }
            _memberService.RemoveMember(removeMember);
            return RedirectToAction("ViewAvailableMembers");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}