using System.ComponentModel.DataAnnotations;

namespace KudumbashreeManagementSystem.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        [Display(Name = "Full Name")]

        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be exactly 10 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone must contain only digits.")]
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Joining Date")]
        public DateTime JoinDate { get; set; }

        // Socio-economic and identity information
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Education Status")]
        public string? EducationStatus { get; set; }

        public string? Occupation { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Family size must be greater than 0.")]
        [Display(Name = "Family Size")]
        public int FamilySize { get; set; }

        [Display(Name = "Economic Status")]
        public string? EconomicStatus { get; set; }

        [Required]
        [Display(Name = "Identity Type")]
        public string IdentityType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Identity Number")]
        public string IdentityNumber { get; set; } = string.Empty;

    }
}
