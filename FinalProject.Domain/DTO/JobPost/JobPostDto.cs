using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTO
{
    public class JobPostDto 
    {


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
        public string ?UserId { get; set; }
    }
}
