using FinalProject.DataAccess.Data;
using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.RegisterNeeded;
using FinalProject.Domain.Models.SkillAndCat;
using FinalProject.Identity.Dto;
using FinalProject.Identity.Dto.Helper;
using FinalProject.Identity.DtoUserAndFreelancerRegister;
using FinalProject.Identity.Login;
using FinalProject.Identity.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProject.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly ApplicationDbContext _context;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _context = context;

        }
        public async Task<AuthModel> RegisterFreelancerAsync(RegisterFreelanceModel model, string selectedRole = "Freelancer")
        {
            var authModel = new AuthModel();

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                authModel.Message = "Email is already registered!";
                return authModel;
            }
            if (await _userManager.FindByNameAsync(model.Username) != null)
            {
                authModel.Message = "Username is already registered!";
                return authModel;
            }
            if (model.ProfilePicture != null)
            {

                //Country
                if (model.Country == null)
                {
                    authModel.Message = "Enter Your Counrty Name.";
                    return authModel;
                }
                var country = _context.Countries.FirstOrDefault(c => c.Id == model.Country);
                if (country == null)
                {
                    authModel.Message = "Invalid Country Name.";
                    return authModel;
                }


                //Langauge
                if (model.SelectedLanguages != null)
                {
                    foreach (var langValue in model.SelectedLanguages)
                    {
                        var language = _context.Languages.FirstOrDefault(l => l.Id == langValue);

                        if (language == null)
                        {
                            authModel.Message = $"Invalid Languages : {langValue}.";
                            return authModel;
                        }
                    }
                }
                else
                {
                    authModel.Message = "Enter Your Languages.";
                    return authModel;
                }


                var UserLanguages = model.SelectedLanguages?.Select(langValue => new ApplicationUserLanguage
                {
                    LanguageValue = langValue,
                }).ToList();
                if (UserLanguages == null)
                {
                    authModel.Message = "Please Enter Your Languges";
                    return authModel;
                }

                //Skill
                var userSkills = model.SelectedSkills?.Select(skillName => new UserSkill
                {
                    SkillId = skillName,
                }).ToList();
                if (userSkills == null || !userSkills.Any())
                {
                    authModel.Message = "Please Enter Your Skills";
                    return authModel;
                }

                if (model.Address == null)
                {
                    authModel.Message = $"Address Required";
                    return authModel;
                }
                if (model.PhoneNumber == null)
                {
                    authModel.Message = $"PhoneNumber Required";
                    return authModel;
                }
                if (model.Age == null)
                {
                    authModel.Message = $"Age Required";
                    return authModel;
                }
                if (model.Description == null)
                {
                    authModel.Message = $"Description Required";
                    return authModel;
                }

                if (model.YourTitle == null)
                {
                    authModel.Message = $"YourTitle Required";
                    return authModel;
                }
                if (model.ZIP == null)
                {
                    authModel.Message = $"ZIP Required";
                    return authModel;
                }
                if (model.PortfolioURl == null)
                {
                    authModel.Message = $"Portfolio URl Required";
                    return authModel;
                }
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CountryId = model.Country,
                    Country = country,
                    Address = model.Address,
                    CodePhone = country.Phonecode,
                    PhoneNumber = model.PhoneNumber,
                    Age = model.Age,
                    UserLanguages = UserLanguages,
                    PortfolioURl = model.PortfolioURl,
                    Description = model.Description,
                    UserSkills = userSkills,
                    ZIP = model.ZIP,
                    YourTitle = model.YourTitle,
                    Education = model.Education,
                    HourlyRate = model.HourlyRate,
                    Experience = model.Experience,
                    RegistrationDate = DateTime.Now,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                    authModel.Message = $"User registration failed: {errors}";
                    return authModel;
                }

                await _userManager.AddToRoleAsync(user, "Freelancer");

                var jwtSecurityToken = await CreateJwtToken(user);

                return new AuthModel
                {
                    Email = user.Email,
                    Country = user.CountryId,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = (List<string>)await _userManager.GetRolesAsync(user),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };
            }
            else
            {
                authModel.Message = "Profile picture is required.";
                return authModel;
            }
        }
        public async Task<AuthModel> RegisterUserAsync(RegisterUserModel model, string selectedRole = "User")
        {
            var authModel = new AuthModel();

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                authModel.Message = "Email is already registered!";
                return authModel;
            }

            if (await _userManager.FindByNameAsync(model.Username) != null)
            {
                authModel.Message = "Username is already registered!";
                return authModel;
            }
            //Country
            if (model.Country == null)
            {
                authModel.Message = "Enter Your Counrty Name.";
                return authModel;
            }
            var country = _context.Countries.FirstOrDefault(c => c.Id == model.Country);
            if (country == null)
            {
                authModel.Message = "Invalid Country Name.";
                return authModel;
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CountryId = model.Country,
                Country = country,
                RegistrationDate = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                authModel.Message = $"User registration failed: {errors}";
                return authModel;
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Email = user.Email,
                Country = user.CountryId,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = (List<string>)await _userManager.GetRolesAsync(user),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };

        }
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var rolesList = await _userManager.GetRolesAsync(user);
            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;

            authModel.Roles = rolesList.ToList();

            return authModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInHours),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

    }
}
