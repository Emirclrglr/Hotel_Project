using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAPIController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestAPIController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult TotalGuests()
        {
            var values = _guestService.TotalGuestCount();
            return Ok(values);
        }
    }
}
