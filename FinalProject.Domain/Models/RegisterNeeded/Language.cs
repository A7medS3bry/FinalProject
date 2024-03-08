using FinalProject.Domain.Models.RegisterNeeded;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.Models.RegisterNeeded
{
    public class Language
    {
        [Key]
        public string Id { get; set; }
        public string Value { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public List<ApplicationUserLanguage> UserLanguages { get; set; }

    }
}
