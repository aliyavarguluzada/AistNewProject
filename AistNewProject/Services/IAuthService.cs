using AistNewProject.Entities;

namespace AistNewProject.Services
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
        public string ValidateToken(string token);
    }
}
