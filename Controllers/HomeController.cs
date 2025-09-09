using Microsoft.AspNetCore.Mvc;
using ClaimingSystem.Services;
using ClaimingSystem.Models;


namespace ClaimingSystem.Controllers
{
    public class HomeController : Controller
    {
    private readonly IClaimStore _store;
    public HomeController(IClaimStore store) { _store = store; }

        public IActionResult Index()
        {
            // quick debug: show counts in console while developing
            System.Console.WriteLine($"Store has {_store.Count()} total claims");

            // Build a small viewmodel for the dashboard (simple and easy to read)
            var model = new DashboardViewModel
            {
                PendingCount = _store.Query(c => c.Status == "Submitted" || c.Status == "Draft").Count(),
                ApprovedCount = _store.Query(c => c.Status == "Approved").Count(),
                RecentCount = _store.GetAll().OrderByDescending(c => c.SubmittedAt).Take(5).Count(),
                RecentClaims = _store.GetAll().OrderByDescending(c => c.SubmittedAt).Take(5).Select(c => new RecentClaimViewModel { Id = c.Id, LecturerName = c.LecturerName, Program = c.Program, Status = c.Status, SubmittedAt = c.SubmittedAt }).ToList()
            };
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
