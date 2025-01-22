using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardLast6BookingsViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public _DashboardLast6BookingsViewPartial(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}BookingAPI/GetLast6Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
