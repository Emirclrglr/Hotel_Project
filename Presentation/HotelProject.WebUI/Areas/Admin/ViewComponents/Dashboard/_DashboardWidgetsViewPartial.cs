using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardWidgetsViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public _DashboardWidgetsViewPartial(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        private async Task StaffCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}StaffAPI/TotalStaffCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            ViewBag.StaffCount = values;
        }

        private async Task BookingCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}BookingAPI/BookingCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            ViewBag.BookingCount = values;
        }

        private async Task GuestCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}BookingAPI");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData);
            var adultCount = values.Sum(x => x.AdultCount);
            var childCount = values.Sum(x => x.ChildCount);
            var totalGuests = adultCount + childCount;
            ViewBag.GuestCount = totalGuests;
        }

        private async Task SubscriberCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}SubscribeAPI/SubscriberCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            ViewBag.SubscriberCount = values;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await StaffCount();
            await BookingCount();
            await GuestCount();
            await SubscriberCount();
            return View();
        }
    }
}
