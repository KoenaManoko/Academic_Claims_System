using System;

namespace ClaimingSystem.Models
{
    public class RecentClaimViewModel
    {
        public int Id { get; set; }
        public string? LecturerName { get; set; }
        public string? Program { get; set; }
        public string? Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
