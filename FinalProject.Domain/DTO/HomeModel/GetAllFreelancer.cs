using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.DTO.HomeModel
{
    public class GetAllFreelancer
    {
        public string id { get; set; }
        public string FullName { get; set; }
        public string? Description { get; set; }
        public decimal? HourlyRate { get; set; }

    }
}
