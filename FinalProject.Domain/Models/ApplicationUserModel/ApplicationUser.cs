
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.Domain.Models.NotificationAndMessageModel;
using FinalProject.Domain.Models.FavoritesTable;
using FinalProject.Domain.Models.ReportModel;
using FinalProject.Domain.Models.RatingModel;
using FinalProject.Domain.Models.ProtfolioModle;
using FinalProject.Domain.Models.SkillAndCat;
using FinalProject.Domain.Models.RegisterNeeded;


namespace FinalProject.Domain.Models.ApplicationUserModel
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }

        [DisplayName("Job Title")]
        public string? YourTitle { get; set; } //

        [DisplayName("About You")]
        [MaxLength(4000)]
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public decimal? HourlyRate { get; set; }
        public int? Age { get; set; }
        public int? ZIP { get; set; }
        //public string? CodePhone { get; set; }
        

        [DisplayName("LinkedIn URl")]
        public string? PortfolioURl { get; set; }
        public DateTime RegistrationDate { get; set; } // Defult Value Date.now
        public DateTime LastActive { get; set; }
        public string? ActiveOrNot { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        //Country
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; } // City

        //[ForeignKey("Country")]
        //public int CountryId { get; set; }
        //public Country  Country { get; set; }

        //Language
        [DisplayName("Langauges")]
        public List<ApplicationUserLanguage>? UserLanguages { get; set; }

        //Skill
        [DisplayName("Your Skills")]
        public virtual List<UserSkill>? UserSkills { get; set; }

        //Jobpost
        public List<JobPost>? JobPosts { get; set; }

        //Protfolio
        public List<Protfolio>? Protfolios { get; set; }

        //Review
        public List<Review>? Reviews { get; set; }

        //Reports
        public List<Reports>? Reports { get; set; }

        //Contract
        public List<Contract>? Contracts { get; set; }

        //ApplyTask or Orders
        public List<ApplyTask>? ApplyTasks { get; set; }

        //Notification
        public List<Notification>? Notifications { get; set; }
        //Favorites
        public List<Favorites>? Favorites { get; set; }
    }
}
