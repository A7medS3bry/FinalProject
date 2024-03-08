using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject.Domain.AccountModel
{
    public class ChangeAboutModel
    {
        public string YourTitle { get; set; }

        [DisplayName("About You")]
        [MaxLength(4000)]
        public string Description { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public decimal HourlyRate { get; set; }
        [DisplayName("LinkedIn URl")]
        public string? PortfolioURl { get; set; }
    }
}
