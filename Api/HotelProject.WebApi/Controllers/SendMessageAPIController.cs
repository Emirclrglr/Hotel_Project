using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageAPIController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;
        public SendMessageAPIController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessageList()
        {
            var values = await _sendMessageService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SendMessageById(int id)
        {
            var values = await _sendMessageService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("SentMessageCount")]
        public IActionResult SentMessageCount()
        {
            var count = _sendMessageService.TSentMessageCount();
            return Ok(count);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSendMessage(CreateSendMessageDto dto)
        {
            dto.SendDate = DateTime.Parse(DateTime.Now.ToString());
            var map = _mapper.Map<SendMessage>(dto);
            await _sendMessageService.TInsertAsync(map);
            return Ok();
        }
    }
}
