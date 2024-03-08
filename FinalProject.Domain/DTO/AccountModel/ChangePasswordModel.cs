using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.AccountModel
{
    public class ChangePasswordModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }


    }
}
