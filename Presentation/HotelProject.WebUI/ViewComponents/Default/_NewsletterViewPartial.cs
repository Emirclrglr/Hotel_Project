using System.Text;
using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _NewsletterViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public _NewsletterViewPartial(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync(CreateSubscribeDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiUrl.BaseUrl}SubscribeAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View("Default", dto);
            }
            return View();
        }
    }
}
