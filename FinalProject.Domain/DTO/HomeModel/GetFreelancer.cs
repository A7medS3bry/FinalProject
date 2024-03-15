using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.HomeModel
{
    public class GetFreelancer
    {

        public string id { get; set; }
        public string FullName { get; set; }
        public string? YourTitle { get; set; }
        public string? Description { get; set; }
        public List<string>? SelectedLanguages { get; set; }
        public virtual List<string>? SelectedSkills { get; set; }
        public string? PortfolioURl { get; set; }
        public string ProfilePicture { get; set; }
        public string? Address { get; set; }
        public string Country { get; set; }
        public decimal? HourlyRate { get; set; }

    }
}
