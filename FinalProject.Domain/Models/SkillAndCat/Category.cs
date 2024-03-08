
using FinalProject.Domain.Models.JobPostAndContract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.Models.SkillAndCat
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public List<SkillCategory> SkillCategories { get; set; }
        public List<JobPost> JobPosts { get; set; }

    }
}
