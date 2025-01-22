using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserAPIController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserAPIController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserListWithWorkLocation()
        {
            var values = await _appUserService.TUserListWithWorkLocation();
            return Ok(values);
        }
    }
}
