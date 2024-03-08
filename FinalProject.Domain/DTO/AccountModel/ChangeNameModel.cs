using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.AccountModel
{
    public class ChangeNameModel
    {
        [Required]
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }
    }
}
