// ApplicationDbContext left as a minimal placeholder to satisfy tooling during refactor.
// The project now uses an in-memory store for the prototype; EF Core was removed.
using Microsoft.EntityFrameworkCore;
using ClaimingSystem.Models;

namespace ClaimingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Claim> Claims { get; set; }
    }
}
