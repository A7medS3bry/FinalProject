using FinalProject.Domain.Models.SkillAndCat;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.JobPostAndContract
{
    public class JobPostSkill
    {
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        [ForeignKey("JobPost")]
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }
    }
}
