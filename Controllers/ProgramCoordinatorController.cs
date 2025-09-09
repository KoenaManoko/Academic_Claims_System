using Microsoft.AspNetCore.Mvc;
using ClaimingSystem.Models;
using ClaimingSystem.Services;

namespace ClaimingSystem.Controllers
{
    public class ProgramCoordinatorController : Controller
    {
    private readonly IClaimStore _store;
    public ProgramCoordinatorController(IClaimStore store) { _store = store; }

        public IActionResult Index(int page = 1, string? status = null)
        {
            const int pageSize = 5;
            var all = _store.GetAll().AsQueryable();
            var query = all;
            if (!string.IsNullOrEmpty(status)) query = query.Where(c => c.Status == status);
            var total = query.Count();
            var claims = query.OrderByDescending(c => c.SubmittedAt).Skip((page-1)*pageSize).Take(pageSize).ToArray();
            ViewData["Total"] = total;
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["StatusFilter"] = status;
            return View(claims);
        }

        public IActionResult Verify(int id)
        {
            // student: quick lookup by id to show the claim in the verify view
            System.Console.WriteLine($"ProgramCoordinator: loading claim {id}");
            var model = _store.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult VerifyConfirm(int id)
        {
            var c = _store.Get(id);
            if (c == null) return NotFound();
            c.Status = "Verified by PC";
            _store.Update(c);
            return RedirectToAction("Index");
        }
    }
}
