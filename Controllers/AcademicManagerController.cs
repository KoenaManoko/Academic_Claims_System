using Microsoft.AspNetCore.Mvc;
using ClaimingSystem.Models;
using ClaimingSystem.Services;

namespace ClaimingSystem.Controllers
{
    public class AcademicManagerController : Controller
    {
    private readonly IClaimStore _store;
    public AcademicManagerController(IClaimStore store) { _store = store; }

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

        public IActionResult Approve(int id)
        {
            // student note: checking the claim before approval
            System.Console.WriteLine($"AcademicManager: Approve view for {id}");
            var model = _store.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult ApproveConfirm(int id)
        {
            var c = _store.Get(id);
            if (c == null) return NotFound();
            c.Status = "Approved";
            _store.Update(c);
            return RedirectToAction("Index");
        }
    }
}
