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
        [Required, MinLength(2), MaxLength(25)]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Display(Name = "Languages")]
        public List<string>? SelectedLanguages { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? YourTitle { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public decimal? HourlyRate { get; set; }

        [DisplayName("Your Skills")]
        public virtual List<int>? SelectedSkills { get; set; }
        public int Country { get; set; }
        public int? ZIP { get; set; }
        public string? Address { get; set; }
        public string? PortfolioURl { get; set; }
        public string ProfilePicture { get; set; }
    }
}
