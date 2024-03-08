using FinalProject.DataAccess.Data;
using FinalProject.Domain.IRepository;
using FinalProject.Domain.Models.JobPostAndContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DataAccess.Repository
{
    public class JobPostRepository : Repository<JobPost>, IJobPostRepository
    {
        ApplicationDbContext _context;
        public JobPostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void Update(JobPost entity)
        {
            JobPost jobPostDB = _context.JobPosts.FirstOrDefault(j =>  j.Id == entity.Id);
            if (jobPostDB != null)
            {
                jobPostDB.Price = entity.Price;
                jobPostDB.Description = entity.Description;
                jobPostDB.Favorites = entity.Favorites;
                jobPostDB.Status = entity.Status;
                jobPostDB.DurationTime = entity.DurationTime;
            }
        }
    }
}
