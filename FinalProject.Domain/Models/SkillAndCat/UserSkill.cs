
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProject.Domain.Models.ApplicationUserModel;

namespace FinalProject.Domain.Models.SkillAndCat
{
    public class UserSkill
    {

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
