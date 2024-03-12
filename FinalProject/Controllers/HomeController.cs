using FinalProject.Domain.DTO.AccountModel;
using FinalProject.Domain.DTO.HomeModel;
using FinalProject.Domain.Models.ApplicationUserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("Get-All-Freelancer-With-The-SameName")]
        public async Task<IActionResult> GetAllFreelancerWithTheSameName(string name)
        {

            var lowercaseName = name.ToLower();

            var users = await _userManager.Users
                .Where(u => (u.FirstName.ToLower() + " " + u.LastName.ToLower()).Contains(lowercaseName))
                .Include(u => u.UserSkills)
                .Include(u => u.UserLanguages)
                .ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found with the specified name.");
            }
            foreach (var user in users)
            {
                var isFreelancer = await _userManager.IsInRoleAsync(user, "Freelancer");

                if (user.Age !=null || user.YourTitle != null || user.Description != null || user.ZIP != null)
                {
                    var freelancers = users.Select(user => new GetFreelancer
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        YourTitle = user.YourTitle,
                        Description = user.Description,
                        SelectedLanguages = user.UserLanguages?.Select(lang => lang.LanguageValue).ToList(),
                        SelectedSkills = user.UserSkills?.Select(skill => skill.SkillId).ToList(),
                        PortfolioURl = user.PortfolioURl,
                        ProfilePicture = user.ProfilePicture,
                        Address = user.Address,
                        Country = user.CountryId,
                        HourlyRate = user.HourlyRate
                    }).ToList();

                    return Ok(freelancers);
                }
            }
            return NotFound("No users found with the specified name.");
        }
    }
}
