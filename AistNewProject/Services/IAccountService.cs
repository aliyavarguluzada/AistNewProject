using AistNewProject.Entities;
using AistNewProject.Requests;

namespace AistNewProject.Services
{
    public interface IAccountService
    {
        public Task<User> Register(RegisterRequest request);
        public Task<string> Login(LoginRequest request);


    }
}
