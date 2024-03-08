using FinalProject.Domain.Models.ApplicationUserModel;

namespace FinalProject.Domain.Models.RegisterNeeded
{
    public class ApplicationUserLanguage
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string LanguageValue { get; set; }
        public Language Language { get; set; }
    }
}
