using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationAPIController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;
        private readonly IMapper _mapper;
        public WorkLocationAPIController(IWorkLocationService workLocationService, IMapper mapper)
        {
            _workLocationService = workLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkLocationList()
        {
            var values = await _workLocationService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLocationById(int id)
        {
            var values = await _workLocationService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkLocation(CreateWorkLocationDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<WorkLocation>(dto);
                await _workLocationService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<WorkLocation>(dto);
                await _workLocationService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var value = await _workLocationService.TGetByIdAsync(id);
            await _workLocationService.TDelete(value);
            return Ok();
        }
    }
}
