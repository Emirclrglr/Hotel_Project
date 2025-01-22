using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomAPIController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> RoomList() => Ok(await _roomService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id) => Ok(await _roomService.TGetByIdAsync(id));

        [HttpGet("GetLast3Rooms")]
        public async Task<IActionResult> GetLast3Rooms() => Ok(await _roomService.TGetLast3Rooms());

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Room>(dto);
                await _roomService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _roomService.TGetByIdAsync(id);
                await _roomService.TDelete(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Room>(dto);
                await _roomService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
