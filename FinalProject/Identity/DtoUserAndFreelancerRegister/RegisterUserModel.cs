using System.ComponentModel.DataAnnotations;

namespace FinalProject.Identity.DtoUserAndFreelancerRegister
{
    public class RegisterUserModel
    {
        [Required, MinLength(2), MaxLength(25)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string LastName { get; set; }
        [Required, MinLength(2), MaxLength(25)]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Country { get; set; }
    }
}
