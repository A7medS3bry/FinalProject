using FinalProject.Domain.Models.ApplicationUserModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.Models.RegisterNeeded
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string Nicename { get; set; }
        public string Iso3 { get; set; }
        public int? Numcode { get; set; }
        public int Phonecode { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}
