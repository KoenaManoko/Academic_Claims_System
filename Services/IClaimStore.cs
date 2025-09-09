using ClaimingSystem.Models;
using System.Collections.Generic;

namespace ClaimingSystem.Services
{
    // Student-friendly interface for a transient claim store used by the prototype.
    // The data in any implementation is intended to be ephemeral for the running app.
    public interface IClaimStore
    {
        IEnumerable<Claim> GetAll();
        Claim? Get(int id);
        void Add(Claim claim);
        void Update(Claim claim);
        int Count();
        IEnumerable<Claim> Query(System.Func<Claim, bool> predicate);
    }
}
