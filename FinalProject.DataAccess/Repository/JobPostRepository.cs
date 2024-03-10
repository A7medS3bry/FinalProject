using FinalProject.DataAccess.Data;
using FinalProject.Domain.IRepository;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.DTO;
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


        public void Update(int id, JobPostDto jobPostDto)
        {
            // jobPost always exist
            JobPost NewJobPost = _context.JobPosts.FirstOrDefault(post => post.Id == id);

            NewJobPost.Title = jobPostDto.Title;
            NewJobPost.Description = jobPostDto.Description;
            NewJobPost.Price = jobPostDto.Price;
            NewJobPost.DurationTime = jobPostDto.DurationTime;
        }

        public void Create(JobPostDto jobPostDto)
        {

            JobPost jobPost = new JobPost();


            jobPost.Title = jobPostDto.Title;
            jobPost.Description = jobPostDto.Description;
            jobPost.Price = jobPostDto.Price;
            jobPost.DurationTime = jobPostDto.DurationTime;
            jobPost.Status = "Uncompleted";
            jobPost.CategoryId = 3;
            jobPost.UserId = "be258344-4614-4f6c-b431-e1a161b2bd26";
            _context.JobPosts.Add(jobPost);
            _context.SaveChanges();

        }
    }
}
