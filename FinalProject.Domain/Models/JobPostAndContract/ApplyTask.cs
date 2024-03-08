using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.NotificationAndMessageModel;
using FinalProject.Domain.Models.RatingModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.JobPostAndContract
{
    public class ApplyTask
    {
        [Key]
        public int Id { get; set; }
        // It must has a default value DataTime.Now
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [RegularExpression("^(Pending|Complete|In progress|Cancel)$", ErrorMessage = "Status must be either 'Pending' or 'Complete' or 'In progress' or 'Cancel'.")]
        public string? Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        [RegularExpression("^(Pending|Paid|Refund)$", ErrorMessage = "Status must be either 'Pending' or 'Paid'  or 'Refund'.")]
        public string? PaymentStatus { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }

        //JobPostId
        [ForeignKey("JobPost")]
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        //Freelancer
        [ForeignKey("Freelancer")]
        public string FreelancerId { get; set; }
        public ApplicationUser Freelancer { get; set; }
        //Client
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
        //Review 
        [ForeignKey("Review")]
        public string? ReviewId { get; set; }
        public Review Review { get; set; }

        //Notification
        public List<Notification> Notifications { get; set; }
    }
}
