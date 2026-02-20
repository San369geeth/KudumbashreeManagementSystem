using System.ComponentModel.DataAnnotations;

namespace KudumbashreeManagementSystem.ViewModels
{
    public class MemberIndexViewModel
    {
        public int MemberId { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        [Display(Name = "Phone no")]
        public string Phone { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoinDate { get; set; }

    }
}
