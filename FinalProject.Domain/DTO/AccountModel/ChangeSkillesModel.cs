using FinalProject.Domain.Models.SkillAndCat;
using System.ComponentModel;

namespace FinalProject.Domain.AccountModel
{
    public class ChangeSkillesModel
    {
        [DisplayName("Your Skills")]
        public virtual List<int>? SelectedSkills { get; set; }
    }
}
