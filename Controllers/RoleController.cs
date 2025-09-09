using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace ClaimingSystem.Controllers
{
    public class RoleController : Controller
    {
        [HttpPost]
        public IActionResult Set(string role, string returnUrl = "/")
        {
            if (string.IsNullOrEmpty(role)) role = "Lecturer";
            Response.Cookies.Append("CurrentRole", role, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(7) });
            return LocalRedirect(returnUrl);
        }
    }
}
