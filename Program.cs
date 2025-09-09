using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// EF Core and ApplicationDbContext removed; using in-memory repository instead
using System.IO;

// Student note: setting up a minimal web host for the assignment prototype.
// I kept this simple so it's easy to understand when demonstrating functionality.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Use an in-memory repository for this prototype so data is cleared when the app stops
// Register the singleton in-memory store used by the prototype.
// Use the ClaimingSystem.Services namespace so it matches the source files.
builder.Services.AddSingleton<ClaimingSystem.Services.IClaimStore, ClaimingSystem.Services.ClaimStoreMemory>();

var app = builder.Build();

// Ensure upload folder exists (we still want to keep uploaded files while app runs)
var uploadDir = Path.Combine(app.Environment.WebRootPath ?? Path.Combine(app.Environment.ContentRootPath, "wwwroot"), "uploads");
if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
