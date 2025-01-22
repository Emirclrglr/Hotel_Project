using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.ApiService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Areas.Admin.ViewComponents.Admin
{
    public class _AdminHeaderPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _apiUrl;
        public _AdminHeaderPartial(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        private async Task InboxCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}ContactAPI/GetContactCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            ViewBag.InboxCount = values;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Username = $"{user.Firstname} {user.Lastname}";
            await InboxCount();
            return View();
        }
    }
}
