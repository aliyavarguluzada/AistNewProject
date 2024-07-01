using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AistNewProject.Controllers
{
    [ApiController]
    [Route("api/home")]
    [Authorize]
    public class HomeController : ControllerBase
    {

        [HttpGet("home")]
        public string Home()
        {
            return "Auth Successfull";
        }

    }
}
