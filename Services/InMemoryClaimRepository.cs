using ClaimingSystem.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ClaimingSystem.Services
{
    // Lightweight in-memory claim store for the UI prototype.
    // This is intentionally simple: it keeps claims only while the web process runs.
    public class ClaimStoreMemory : IClaimStore
    {
        // Thread-safe dictionary to hold Claim objects during the app lifetime.
        private readonly ConcurrentDictionary<int, Claim> _store = new();
        private int _next = 1;

        public IEnumerable<Claim> GetAll() => _store.Values.OrderBy(c => c.Id);

        public Claim? Get(int id) => _store.TryGetValue(id, out var claim) ? claim : null;

        public void Add(Claim claim)
        {
            var id = System.Threading.Interlocked.Increment(ref _next);
            claim.Id = id;
            _store.TryAdd(claim.Id, claim);
        }

        public void Update(Claim claim)
        {
            _store[claim.Id] = claim;
        }

        public int Count() => _store.Count;

        public IEnumerable<Claim> Query(System.Func<Claim, bool> predicate) => _store.Values.Where(predicate);
    }
}
