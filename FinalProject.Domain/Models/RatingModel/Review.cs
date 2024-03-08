using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.JobPostAndContract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.RatingModel
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }

        [Range(0, 100)]
        public int TaskCompletesPersentage { get; set; }
        [MaxLength(1000)]
        public string? Comments { get; set; }
        // Default value Date.Now
        public DateTime RateDate { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }



        //Client
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }

        //Freelancer
        [ForeignKey("Freelancer")]
        public string FreelancerId { get; set; }
        public ApplicationUser Freelancer { get; set; }

        //ApplyTask
        [ForeignKey("ApplyTask")]
        public int? ApplyTaskId { get; set; }
        public ApplyTask ApplyTask { get; set; }

    }
}
