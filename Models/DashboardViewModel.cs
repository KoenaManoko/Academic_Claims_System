namespace ClaimingSystem.Models
{
    public class DashboardViewModel
    {
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RecentCount { get; set; }
    public IEnumerable<RecentClaimViewModel>? RecentClaims { get; set; }
    }
}
