using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.FavoritesTable;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.Domain.Models.NotificationAndMessageModel;
using FinalProject.Domain.Models.SkillAndCat;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.JobPostAndContract
{
    public class JobPost
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [MinLength(2)]
        [Required]
        public string Title { get; set; }

        [MaxLength(8000)]
        [MinLength(2)]
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime? DurationTime { get; set; }

        [RegularExpression("^(Completed|Uncompleted)$", ErrorMessage = "Status must be either 'Completed' or 'Uncompleted'.")]
        public string Status { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //ApplicationUSer Relation
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //Category Relation
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Skill Relation
        public List<JobPostSkill> JobPostSkill { get; set; }

        //ApplyJob
        public List<ApplyTask> ApplyTasks { get; set; }

        //Notification
        public List<Notification> Notifications { get; set; }

        //Favorites
        public List<Favorites>? Favorites { get; set; }



    }
}
