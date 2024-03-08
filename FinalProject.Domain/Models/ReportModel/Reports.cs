using FinalProject.Domain.Models.ApplicationUserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.ReportModel
{
    public class Reports
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        [MaxLength(1000)]
        [MinLength(2)]

        public string? Description { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }


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
