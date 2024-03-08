using FinalProject.Identity.Dto;
using FinalProject.Identity.DtoUserAndFreelancerRegister;
using FinalProject.Identity.Login;
using FinalProject.Identity.Role;

namespace FinalProject.Identity.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterUserAsync(RegisterUserModel model, string selectedRole = "User");
        Task<AuthModel> RegisterFreelancerAsync(RegisterFreelanceModel model, string selectedRole = "Freelancer");
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
