using FinalProject.Domain.Models.JobPostAndContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.HomeModel
{
    public class JopPostsView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? DurationTime { get; set; }
        public string Category { get; set; }
        public string FullNameForUser { get; set; }
        public string Status { get; set; }
        public List<string> JobPostSkill { get; set; }
    }
}
