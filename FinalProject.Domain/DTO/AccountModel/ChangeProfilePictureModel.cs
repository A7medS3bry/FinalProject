using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.AccountModel
{
    public class ChangeProfilePictureModel
    {
        [Required]
        public string NewProfilePictureUrl { get; set; }
    }
}
