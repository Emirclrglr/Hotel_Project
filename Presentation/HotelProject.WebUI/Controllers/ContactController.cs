using System.Text;
using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;

        public ContactController(IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ContactForm()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ContactForm(CreateContactDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            dto.ContactDate = DateTime.Parse(DateTime.Now.ToString());
            StringContent content = new(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiUrl.BaseUrl}ContactAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
