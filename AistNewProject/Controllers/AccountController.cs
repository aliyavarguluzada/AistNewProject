using AistNewProject.Data;
using AistNewProject.Entities;
using AistNewProject.Requests;
using AistNewProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AistNewProject.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        public AccountController(ApplicationDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<User> Register(RegisterRequest request) => await _accountService.Register(request);


        [HttpPost("login")]
        public async Task<string> Login(LoginRequest request) => await _accountService.Login(request);

    }
}
