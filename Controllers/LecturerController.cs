using Microsoft.AspNetCore.Mvc;
using ClaimingSystem.Models;
using ClaimingSystem.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;

namespace ClaimingSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly IClaimStore _store;
        private readonly IWebHostEnvironment _env;

        public LecturerController(IClaimStore store, IWebHostEnvironment env)
        {
            _store = store;
            _env = env;
        }

        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(Claim claim, IFormFile? attachment)
        {
            if (!ModelState.IsValid)
            {
                return View(claim);
            }

            claim.Status = "Submitted";
            claim.SubmittedAt = System.DateTime.Now;
            if (attachment != null && attachment.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot"), "uploads");
                var fileName = Path.GetRandomFileName() + Path.GetExtension(attachment.FileName);
                var filePath = Path.Combine(uploads, fileName);
                // Student note: saving files with a random file name to avoid collisions.
                // Not production-safe but fine for a simple prototype/Demo.
                using (var stream = System.IO.File.Create(filePath))
                {
                    await attachment.CopyToAsync(stream);
                }
                claim.AttachmentFileName = fileName;
            }
            _store.Add(claim);
            // in-memory repo persists only while app is running
            return RedirectToAction("Status", new { id = claim.Id });
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult Status(int id)
        {
            var model = _store.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}
