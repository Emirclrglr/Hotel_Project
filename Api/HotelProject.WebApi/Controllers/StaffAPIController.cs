using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAPIController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        public StaffAPIController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> StaffList() => Ok(await _staffService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> StaffGetById(int id) => Ok(await _staffService.TGetByIdAsync(id));

        [HttpGet("TotalStaffCount")]
        public IActionResult TotalStaffCount() => Ok(_staffService.TTotalStaffCount());

        [HttpGet("GetLast4Staff")]
        public async Task<IActionResult> GetLast4Staff() => Ok(await _staffService.TGetLast4Staff());

        [HttpPost]
        public async Task<IActionResult> AddStaff(CreateStaffDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Staff>(dto);
                await _staffService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _staffService.TGetByIdAsync(id);
                await _staffService.TDelete(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Staff>(dto);
                await _staffService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
