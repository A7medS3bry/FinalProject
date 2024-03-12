using FinalProject.Domain.Models.JobPostAndContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.IRepository
{
    public interface IHomeRepository
    {
        public IEnumerable<JobPost> GetAllWithName(string name);
        public JobPost GetAllWithId(int id);
    }
}
