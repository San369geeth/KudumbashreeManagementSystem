namespace KudumbashreeManagementSystem.Models
{
    public class MeetingMember
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public bool IsPresent { get; set; } = false;

        public decimal ContributionAmount { get; set; } = 0;
    }
}
