using Microsoft.AspNetCore.Mvc;
using FinalProject.DTO;
using FinalProject.DataAccess.Repository;
using FinalProject.DataAccess.Data;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FinalProject.Domain.DTO.JobPost;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "User")]
    //[Authorize (Roles = "User , Freelancer")]
    public class JobPostsController  : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public JobPostsController( IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet("Get-All-My-Project-Post")]
        public List<GetMyJobPostDto> GetJMyobPosts()
        {
            var userId = User.FindFirst("uid")?.Value;
            
            if (_unitOfWork.JobPostRepository.GetAllJobPostsByUserId(userId) == null)
                return new List<GetMyJobPostDto>();
            return _unitOfWork.JobPostRepository.GetAllJobPostsByUserId(userId).ToList();
        }

        [HttpGet("Get-All-Project-With-Same-Title")]
        public List<AllJopPostDto> GetJMyobPostsWithSameName(string tilte)
        {
            if (_unitOfWork.JobPostRepository.GetAllByName(tilte) == null)
                return new List<AllJopPostDto>();
            return _unitOfWork.JobPostRepository.GetAllByName(tilte);
        }

        // get all job posts
        // GET: api/JobPosts
        [HttpGet("Get-All")]
        public IEnumerable<JobPost> GetJobPosts()
        {
            if (_unitOfWork.JobPostRepository.GetAll() == null)
                return new List<JobPost>();
            return _unitOfWork.JobPostRepository.GetAll();
        }


        // get jobPost by id
        // GET: api/JobPosts/5
        [HttpGet("Get-job-post-by-Id")]
        public IActionResult GetJobPost(int id)
        {
            var jobPost = _unitOfWork.JobPostRepository.GetjopPostWithId(id);
            if (jobPost == null)
            {
                return NotFound();
            }

            return Ok(jobPost);
        }


        // update jobpost
        // PUT: api/JobPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutJobPost(int id, JobPostDto jobPostDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_unitOfWork.JobPostRepository.GetByID(id) == null)
                return NotFound();

            // jobPost always exist
            _unitOfWork.JobPostRepository.Update(id, jobPostDto);
            _unitOfWork.Save();
            return Ok(_unitOfWork.JobPostRepository.GetByID(id));
        }


        // create new jobPost
        // POST: api/JobPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public ActionResult<JobPost> PostJobPost(JobPostDto jobPostDto)
        //{
        // //   jobPostDto.UserId = User.FindFirst("uid").ToString();

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.JobPostRepository.Create(jobPostDto);
        //      //  _unitOfWork.Save();
        //        return Ok(jobPostDto);
        //    }

        //    return BadRequest();
        //}

        [HttpPost]
        public ActionResult<JobPost> PostJobPost(JobPostDto jobPostDto)
        {
            if (ModelState.IsValid)
            {
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userId = User.FindFirst("uid")?.Value;

                if (userId != null)
                {
                    jobPostDto.UserId = userId;
                    Console.WriteLine(jobPostDto.UserId);
                    _unitOfWork.JobPostRepository.Create(jobPostDto);
                    _unitOfWork.Save(); 

                    return Ok(jobPostDto);
                }
                else
                {
                    return BadRequest("User ID not found.");
                }
            }

            return BadRequest(ModelState);
        }



        // DELETE: api/JobPosts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteJobPost(int id)
        {
            JobPost jobPost = _unitOfWork.JobPostRepository.GetByID(id);
            if (jobPost == null) return NotFound();
            _unitOfWork.JobPostRepository.Delete(jobPost);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
