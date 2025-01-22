using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SubscribeDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeAPIController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;
        public SubscribeAPIController(ISubscribeService subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SubscribeList() => Ok(await _subscribeService.TGetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribeById(int id) => Ok(await _subscribeService.TGetByIdAsync(id));

        [HttpGet("SubscriberCount")]
        public IActionResult SubscriberCount() => Ok(_subscribeService.TSubscriberCount());

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(CreateSubscribeDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Subscribe>(dto);
                await _subscribeService.TInsertAsync(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            if (ModelState.IsValid)
            {
                var value = await _subscribeService.TGetByIdAsync(id);
                await _subscribeService.TDelete(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Subscribe>(dto);
                await _subscribeService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
