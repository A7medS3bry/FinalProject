using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.AccountModel
{
    public class FreelancerProfileDto
    {
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Country { get; set; }
        public List<string>? SelectedLanguages { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? YourTitle { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public virtual List<int>? SelectedSkills { get; set; }
        public decimal? HourlyRate { get; set; }
        public int? ZIP { get; set; }
        public string? Address { get; set; }
        public string? PortfolioURl { get; set; }
        public string ProfilePicture { get; set; }

    }
}
