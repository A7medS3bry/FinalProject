using System.ComponentModel.DataAnnotations;

namespace FinalProject.Identity.Password
{
    public class ResetPasswordModel
    {
        [Required]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Passwords Do Not Match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
