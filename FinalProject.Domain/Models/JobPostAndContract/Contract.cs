using FinalProject.Domain.Models.ApplicationUserModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.JobPostAndContract
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TremsAndCondetions { get; set; }
        [Required]
        public decimal Price { get; set; }
        // Default value will be DateTime.Now
        public DateTime ContractDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        //*******************************************
        public string PaymentWay { get; set; }

        [ForeignKey("JobPost")]
        public int JopPostId { get; set; }
        public JobPost JobPost { get; set; }
        //*******************************************

        //Client
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }

        //Freelancer
        [ForeignKey("Freelancer")]
        public string FreelancerId { get; set; }
        public ApplicationUser Freelancer { get; set; }
    }
}
