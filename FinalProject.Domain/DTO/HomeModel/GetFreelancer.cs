using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.HomeModel
{
    public class GetFreelancer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? YourTitle { get; set; }
        public string? Description { get; set; }
        public List<string>? SelectedLanguages { get; set; }
        public virtual List<int>? SelectedSkills { get; set; }
        public string? PortfolioURl { get; set; }
        public string ProfilePicture { get; set; }
        public string? Address { get; set; }
        public int Country { get; set; }
        public decimal? HourlyRate { get; set; }

    }
}
