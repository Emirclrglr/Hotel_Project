using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.AboutDtos;
using HotelProject.WebUI.Dtos.BookingDtos;
using HotelProject.WebUI.Dtos.RoomDtos;
using HotelProject.WebUI.Dtos.StaffDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public _AboutViewPartial(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        private async Task<int> GuestCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}BookingAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData);
                var adultCount = values.Select(x=>x.AdultCount).Sum();
                var childCount = values.Select(x=>x.ChildCount).Sum();
                return adultCount + childCount;
            }
            return 0;
        }

        private async Task<int> StaffCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}StaffAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultStaffDto>>(jsonData);
                return values.Count();
            }
            return 0;
        }

        private async Task<int> RoomCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}RoomAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultRoomDto>>(jsonData);
                return values.Count();
            }
            return 0;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}AboutAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultAboutDto>>(jsonData);
                ViewBag.GuestCount = await GuestCount();
                ViewBag.StaffCount = await StaffCount();
                ViewBag.RoomCount = await RoomCount();
                return View(values);
            }


            return View();
        }
    }
}
