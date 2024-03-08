using FinalProject.Domain.Models.ApplicationUserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.ProtfolioModle
{
    public class Protfolio
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        public string Name { get; set; }
        [MaxLength(4000)]
        [MinLength(2)]
        [Required]
        public string Description { get; set; }

        public string? Media { get; set; }
        public string? URL { get; set; }
        public DateTime? ProjectDate { get; set; }


        //ApplicaitonUser Relation
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
