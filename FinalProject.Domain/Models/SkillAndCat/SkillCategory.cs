using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Models.SkillAndCat
{
    public class SkillCategory
    {
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
