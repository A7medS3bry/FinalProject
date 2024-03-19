using FinalProject.Domain.AccountModel;
using FinalProject.Domain.DTO.AccountModel;
using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.RegisterNeeded;
using FinalProject.Domain.Models.SkillAndCat;
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
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        //Profile User

        [HttpGet("User-Account")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> UserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");
            }

            // Find the user by ID

            var user = await _userManager.FindByNameAsync(userId);

            var userProfileDto = new UserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                Country = user.Country
            };

            // Return the user profile DTO
            return Ok(userProfileDto);
        }
        //Profile Freelancer
        [HttpGet("Freelancer-Account")]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> FreelancerProfile()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User ID not found in claims");
            }


            //            var user = await _userManager.FindByNameAsync(userId);
            var user = await _userManager.Users
                .Include(u => u.UserSkills)
                    .ThenInclude(u=>u.Skill)
                .Include(u=>u.UserLanguages)
                    .ThenInclude(u=>u.Language)
                .SingleOrDefaultAsync(u => u.UserName == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var freelancerProfileDto = new FreelancerProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                SelectedLanguages = user.UserLanguages?.Select(lang => lang.Language.Value).ToList(),
                PhoneNumber = user.CodePhone +" "+ user.PhoneNumber,
                Age = user.Age,
                YourTitle = user.YourTitle,
                Description = user.Description,
                Education = user.Education,
                Experience = user.Experience,
                SelectedSkills = user.UserSkills?.Select(skill => skill.Skill.Name).ToList() ?? new List<string>(),
                HourlyRate = user.HourlyRate,
                ZIP = user.ZIP,
                Address = user.Country +" "+ user.State+" "+ user.Address,
                PortfolioURl = user.PortfolioURl,
                ProfilePicture = user.ProfilePicture
            };

            return Ok(freelancerProfileDto);
        }

        //Password
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            // Extract user ID claim
            var userIdClaim = User.FindFirst("uid");
            Console.WriteLine(userIdClaim);

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
            {
                return BadRequest("Unable to find user");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (changePasswordResult.Succeeded)
            {
                return Ok("Password changed successfully");
            }
            else
            {
                return BadRequest("Failed to change password");
            }
        }
        //ProfilePhoto
        [HttpPost("ChangeProfilePicture")]
        public async Task<IActionResult> ChangeProfilePicture([FromBody] ChangeProfilePictureModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            // Update the profile picture URL
            user.ProfilePicture = model.NewProfilePictureUrl;

            // Save the changes to the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Profile picture changed successfully");
            }
            else
            {
                return BadRequest("Failed to change profile picture");
            }
        }
        //FirstName   Last Nane
        [HttpPost("ChangeName")]
        public async Task<IActionResult> ChangeFirstLastName([FromBody] ChangeNameModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your Name changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your name");
            }
        }
        //PhoneNumber
        [HttpPost("ChangePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] ChangePhoneNumber model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            user.PhoneNumber = model.PhoneNumber;
            user.CodePhone = model.CodePhone;

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your PhoneNumber changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your PhoneNumber");
            }
        }
        //Age  Language   ZIP  Address
        [Authorize(Roles = "Freelancer , Admin")]
        [HttpPost("ChangeYouDitalis")]
        public async Task<IActionResult> ChangeYouDitalis([FromBody] ChangeYouDitalisModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            user.Age = model.Age;
            user.ZIP = model.ZIP;
            user.Address = model.Address;
            user.UserLanguages = model.SelectedLanguages
                .Select(language => new ApplicationUserLanguage { LanguageValue = language })
                .ToList();
            // Save the changes to the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your Ditalis changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your Ditalis");
            }
        }
        //Country
        [HttpPost("ChangeCountry")]
        public async Task<IActionResult> ChangeCountry([FromBody] ChangeCountyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            // Update the profile picture URL
            user.Country = model.Country;

            // Save the changes to the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your Country changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your Country");
            }
        }
        //Shills
        [HttpPost("ChangeSkilles")]
        [Authorize(Roles = "Freelancer , Admin")]
        public async Task<IActionResult> ChangeSkilles([FromBody] ChangeSkillesModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            user.UserSkills = model.SelectedSkills
                .Select(skillId => new UserSkill { SkillId = skillId })
                .ToList();

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your skills changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your skills");
            }
        }
        //AboutYou  Experience  Education  PortfolioURl  Description  YourTitle  HourlyRate
        [HttpPost("ChangeAboutYou")]
        [Authorize(Roles = "Freelancer , Admin")]
        public async Task<IActionResult> ChangeAboutYou([FromBody] ChangeAboutModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var userIdClaim = User.FindFirst("uid");

            if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
            {
                return BadRequest("User ID not found in claims");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            user.Experience = model.Experience;
            user.Education = model.Education;
            user.PortfolioURl = model.PortfolioURl;
            user.Description = model.Description;
            user.YourTitle = model.YourTitle;
            user.HourlyRate = model.HourlyRate;


            // Save the changes to the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return Ok("Your Ditalis changed successfully");
            }
            else
            {
                return BadRequest("Failed to change your Ditalis");
            }
        }


    }
}

