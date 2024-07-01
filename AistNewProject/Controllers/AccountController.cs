using AistNewProject.Data;
using AistNewProject.Entities;
using AistNewProject.Requests;
using AistNewProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AistNewProject.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        public AccountController(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
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
        [HttpPost("login")]
        public async Task<string> Login(LoginRequest request)
        {
            var user = await _context.Users.Where(c => c.Email == request.Email).FirstOrDefaultAsync();

            var validatePass = user.VerifyPassword(request.Password);

            if (validatePass is false)
                return "Password is wrong";

            var token = _authService.GenerateToken(user);

            return token;
        }

    }
}
