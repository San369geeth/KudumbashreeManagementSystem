using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KudumbashreeManagementSystem.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [Required]
        public decimal ExpectedAmount { get; set; } = 50;
        

        public string? Notes { get; set; }

        public ICollection<MeetingMember> MeetingMembers { get; set; } = new List<MeetingMember>();
        [NotMapped]
        public decimal TotalContribution =>
        MeetingMembers?.Sum(mm => mm.ContributionAmount) ?? 0;
        
        // Indicates meeting is closed/finalized and should not be edited
        [Display(Name = "Finalized")]
        public bool IsFinalized { get; set; } = false;
    }
}
