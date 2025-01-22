using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAPIController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceAPIController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList() => Ok(await _serviceService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> ServiceGetById(int id) => Ok(await _serviceService.TGetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Service>(dto);
                await _serviceService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _serviceService.TGetByIdAsync(id);
                await _serviceService.TDelete(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Service>(dto);
                await _serviceService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
