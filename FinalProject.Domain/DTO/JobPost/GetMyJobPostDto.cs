using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.JobPost
{
    public class GetMyJobPostDto
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
        public string CategoryName { get; set; }
        public List<string>? JobPostSkill { get; set; }
        public string? UserId { get; set; }
    }
}
