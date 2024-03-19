using System.ComponentModel.DataAnnotations;

namespace FinalProject.Identity.DtoUserAndFreelancerRegister
{
    public class RegisterUserModel
    {
        [Required, MinLength(2), MaxLength(25)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string LastName { get; set; }
        [EmailAddress ,Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required , Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
