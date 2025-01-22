using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactAPIController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _contactService.TGetListAsync();
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _contactService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            var count = _contactService.TGetContactCount();
            return Ok(count);
        }


        [HttpPost]
        public async Task<IActionResult> InsertContact(CreateContactDto dto)
        {
            dto.ContactDate = DateTime.Parse(DateTime.Now.ToString());
            var map = _mapper.Map<Contact>(dto);
            await _contactService.TInsertAsync(map);
            return Ok();
        }
    }
}
