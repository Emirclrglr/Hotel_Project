using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GenerateToken()
        {
            return Ok(new CreateToken().TokenGenerator()); 
        }

        [HttpGet("[action]")]
        public IActionResult GenerateAdminToken()
        {
            return Ok(new CreateToken().AdminTokenGenerator());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Hoş Geldiniz");
        }

        [Authorize(Roles = "Admin, Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Hoş Geldiniz");
        }
    }
}
