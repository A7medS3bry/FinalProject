
using FinalProject.Domain.Models.JobPostAndContract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.Models.SkillAndCat
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        //User
        public List<UserSkill> UserSkills { get; set; }
        //Catogry
        public List<SkillCategory> SkillCategories { get; set; }
        //JobPost
        public List<JobPostSkill> JobPostSkill { get; set; }
    }
}
