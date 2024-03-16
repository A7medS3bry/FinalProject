using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Identity.Login
{
    public class TokenRequestModel
    {
        [Required ,EmailAddress]
        public string Email { get; set; }
        [Required,PasswordPropertyText]
        public string Password { get; set; }
    }
}
