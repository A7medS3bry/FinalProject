using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.DataAccess.Data;
using FinalProject.Domain.IRepository;
using FinalProject.Domain.Models.JobPostAndContract;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DataAccess.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;
        public HomeRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public JobPost GetAllWithId(int id)
        {
            var jopPost = _context.JobPosts
                .Include(u=>u.Category)
                .Include(u=>u.JobPostSkill).ThenInclude(u=>u.Skill)
                .FirstOrDefault(u => u.Id == id);
            return jopPost;
        }

        public IEnumerable<JobPost> GetAllWithName(string tiltel)
        {
            var lowerTitel = tiltel.ToLower();

            var jobposts = _context.JobPosts
                .Where(job => job.Title.ToLower().Contains(lowerTitel))
                .Include(u=>u.JobPostSkill)
                .Include(u=>u.Category)
                .ToList();

            return jobposts;
        }

    }
}
