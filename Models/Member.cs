using System.ComponentModel.DataAnnotations;

namespace KudumbashreeManagementSystem.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; }=string.Empty;
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
    }
}
