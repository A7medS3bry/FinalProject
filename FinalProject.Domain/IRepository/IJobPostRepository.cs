using FinalProject.Domain.Models.JobPostAndContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.IRepository
{
    public interface IJobPostRepository : IRepository<JobPost>
    {
        
        void Update(JobPost entity);
    }
}
