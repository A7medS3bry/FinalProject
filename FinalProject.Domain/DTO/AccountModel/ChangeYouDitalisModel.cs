
using FinalProject.Domain.Models.RegisterNeeded;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.AccountModel
{
    public class ChangeYouDitalisModel
    {
        public int? Age { get; set; }
        public string? Address { get; set; }
        public int? ZIP { get; set; }

        [Display(Name = "Languages")]
        public List<string>? SelectedLanguages { get; set; }
    }
}
