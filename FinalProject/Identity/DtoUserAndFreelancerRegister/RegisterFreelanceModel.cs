using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Identity.DtoUserAndFreelancerRegister
{
    public class RegisterFreelanceModel
    {
        [Required, MinLength(2), MaxLength(25)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password)) , Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public List<string>? SelectedLanguages { get; set; }
        //[Required]
        //public string? Phonecode { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
        [Required , Range(18,100)]
        public int? Age { get; set; }
        [Required]
        public string? YourTitle { get; set; }
        [Required]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? Education { get; set; }
        [MaxLength(1000)]
        public string? Experience { get; set; }
        [Range(0, 10000)]
        public decimal? HourlyRate { get; set; }
        [Required]
        
        public virtual List<int>? SelectedSkills { get; set; }
        /// <summary>
        /// ////////
        /// </summary>
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public int ZIP { get; set; }
        public string? PortfolioURl { get; set; }
        [Required, MaxLength(50)]
        public string ProfilePicture { get; set; }
    }
}
