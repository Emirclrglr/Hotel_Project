using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialAPIController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialAPIController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList() => Ok(await _testimonialService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> TestimonialGetById(int id) => Ok(await _testimonialService.TGetByIdAsync(id));


        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Testimonial>(dto);
                await _testimonialService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _testimonialService.TGetByIdAsync(id);
                await _testimonialService.TDelete(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Testimonial>(dto);
                await _testimonialService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
