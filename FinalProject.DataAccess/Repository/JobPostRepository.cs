using FinalProject.DataAccess.Data;
using FinalProject.Domain.DTO.JobPost;
using FinalProject.Domain.IRepository;
using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public List<AllJopPostDto> GetAllByName(string tilte)
        {
            var lower = tilte.ToLower();
            var AllJopPost = _context.JobPosts
                .Include(u=>u.Category)
                .Include(u=>u.ApplicationUser)
                .Where(u => u.Title.ToLower().Contains(lower)).ToList();
            var AllJopPostDto = AllJopPost.Select(jp => new AllJopPostDto
            {
                Title = jp.Title,
                Description = jp.Description,
                Price = jp.Price,
                DurationTime = jp.DurationTime,
                CategoryName = jp.Category.Name,
                Status = jp.Status,
                FullNameForUser = jp.ApplicationUser.FirstName + " " + jp.ApplicationUser.LastName
            }).ToList();

            return AllJopPostDto;

        }
        public List<GetMyJobPostDto> GetAllJobPostsByUserId(string userId)
        {
            var jobPosts = _context.JobPosts
                .Include(jp => jp.JobPostSkill)
                    .ThenInclude(u=>u.Skill)
                .Include(u=>u.Category)
                .Where(jp => jp.UserId == userId).ToList();

            var jobPostDtos = jobPosts.Select(jp => new GetMyJobPostDto
            {
                Title = jp.Title,
                Description = jp.Description,
                CategoryName = jp.Category.Name,
                Price = jp.Price,
                DurationTime = jp.DurationTime,
                JobPostSkill = jp.JobPostSkill.Select(skill => skill.Skill.Name).ToList(),
                UserId = jp.UserId,
            }).ToList();

            return jobPostDtos;
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

        //public void Create(JobPostDto jobPostDto)
        //{

        //    JobPost jobPost = new JobPost();



        //    jobPost.Title = jobPostDto.Title;
        //    jobPost.Description = jobPostDto.Description;
        //    jobPost.Price = jobPostDto.Price;
        //    jobPost.DurationTime = jobPostDto.DurationTime;
        //    jobPost.Status = "Uncompleted";
        //    jobPost.CategoryId = 3;
        //    jobPost.UserId = "be258344-4614-4f6c-b431-e1a161b2bd26";
        //    _context.JobPosts.Add(jobPost);
        //    _context.SaveChanges();

        //}

        public void Create(JobPostDto jobPostDto)
        {
            JobPost jobPost = new JobPost();

            // Use the provided userId instead of accessing User object
            jobPost.UserId = jobPostDto.UserId;

            jobPost.Title = jobPostDto.Title;
            jobPost.Description = jobPostDto.Description;
            jobPost.Price = jobPostDto.Price;
            jobPost.DurationTime = jobPostDto.DurationTime;
            jobPost.Status = "Uncompleted";
            jobPost.JobPostSkill = jobPostDto.JobPostSkill.Select(skillId => new JobPostSkill { SkillId = skillId }).ToList();
            jobPost.CategoryId = jobPostDto.CategoryId;

            _context.JobPosts.Add(jobPost);
            _context.SaveChanges();
        }

    }
}
