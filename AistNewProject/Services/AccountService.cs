using AistNewProject.Data;
using AistNewProject.Entities;
using AistNewProject.Requests;
using Microsoft.EntityFrameworkCore;

namespace AistNewProject.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AccountService(IAuthService authService, ApplicationDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        public async Task<string> Login(LoginRequest request)
        {
            if (request.Email == string.Empty || request.Password == string.Empty)
                return "Email or password is wrong";


            var user = await _context.Users.Where(c => c.Email == request.Email).FirstAsync();

            if (user is null)
                return "No such User Exists";

            var validatePass = user.VerifyPassword(request.Password);

            if (validatePass is false)
                return "Password is wrong";

            var token = _authService.GenerateToken(user);

            return token;
        }

        public async Task<User> Register(RegisterRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,

            };
            newUser.CreatePassword(request.Password);

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
