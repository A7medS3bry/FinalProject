using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.JobPostAndContract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.NotificationAndMessageModel
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [MaxLength(1000)]
        [MinLength(1)]
        public string Message { get; set; }
        // Default value will be DataTime.Now
        public DateTime NOtificationTime { get; set; }

        [RegularExpression("^(Read|Unread)$", ErrorMessage = "Status must be either 'Read' or 'Unread'.")]
        public string Statues { get; set; }
        //User
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //ApplyTask
        [ForeignKey("ApplyTask")]
        public int? ApplyTaskId { get; set; }
        public ApplyTask ApplyTask { get; set; }

        //Jobpost
        [ForeignKey("JobPost")]
        public int? JobPostId { get; set; }
        public JobPost JobPost { get; set; }
    }
}
