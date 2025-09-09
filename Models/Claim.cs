using System;

namespace ClaimingSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Claim
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Lecturer Name")]
        public string? LecturerName { get; set; }

        [Required]
        public string? Program { get; set; }

        public string? Status { get; set; } = "Draft";
        public DateTime SubmittedAt { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }
        public string? AttachmentFileName { get; set; }
    }
}
