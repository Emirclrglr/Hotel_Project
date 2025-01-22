using System.Text;
using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.BookingDtos;
using HotelProject.WebUI.Dtos.RoomDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public BookingController(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;

        }

        private async Task RoomsDropdownList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}RoomAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultRoomDto>>(jsonData);
                IEnumerable<SelectListItem> items = (from item in values.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = item.RoomTitle,
                                                         Value = item.RoomId.ToString()
                                                     }).ToList();
                ViewBag.RoomList = items;
            }
        }

        public async Task<IActionResult> Index()
        {
            await RoomsDropdownList();
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> _BookingFormPartial()
        {
            await RoomsDropdownList();
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _BookingFormPartial(CreateBookingDto dto)
        {
            dto.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            StringContent content = new(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiUrl.BaseUrl}BookingAPI", content);
            await RoomsDropdownList();
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }

            return View();

        }
    }

}


