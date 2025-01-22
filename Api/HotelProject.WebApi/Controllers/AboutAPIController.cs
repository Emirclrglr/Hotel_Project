using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AboutDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutAPIController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutAPIController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutList() => Ok(await _aboutService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id) => Ok(await _aboutService.TGetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<About>(dto);
                await _aboutService.TInsertAsync(map);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _aboutService.TGetByIdAsync(id);
                await _aboutService.TDelete(value);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<About>(dto);
                await _aboutService.TUpdate(map);
                return Ok();
            }
            return BadRequest();
        }
    }
}
