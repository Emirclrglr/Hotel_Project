using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAPIController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingAPIController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingList()
        {
            var values = await _bookingService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("GetBookingListWithRelations")]
        public async Task<IActionResult> GetBookingListWithRelations()
        {
            var values = await _bookingService.TBookingListWithRelationAsync();
            return Ok(values);
        }
        [HttpGet("GetBookingListWithRelationsId/{id}")]
        public async Task<IActionResult> GetBookingListWithRelationsId(int id)
        {
            var values = await _bookingService.TBookingListWithRelationWithIdAsync(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var values = await _bookingService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var valus = _bookingService.TBookingCount();
            return Ok(valus);
        }

        [HttpGet("GetLast6Booking")]
        public async Task<IActionResult> GetLast6Booking()
        {
            var values = await _bookingService.TGetLast6BookingAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Booking>(dto);
                await _bookingService.TInsertAsync(map);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _bookingService.TGetByIdAsync(id);
            await _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Booking>(dto);
                await _bookingService.TUpdate(map);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("ApproveReservation/{id}")]
        public IActionResult ApproveReservation(int id)
        {
            _bookingService.TApproveReservation(id);
            return Ok();
        }

        [HttpPut("DenyReservation/{id}")]
        public IActionResult DenyReservation(int id)
        {
            _bookingService.TDenyReservation(id);
            return Ok();
        }

        [HttpPut("HoldReservation/{id}")]
        public IActionResult HoldReservation(int id)
        {
            _bookingService.THoldReservation(id);
            return Ok();
        }
    }
}
