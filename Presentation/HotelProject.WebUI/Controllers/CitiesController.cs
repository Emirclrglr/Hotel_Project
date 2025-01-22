using HotelProject.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static HotelProject.WebUI.Areas.Admin.Models.CityVM;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class CitiesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CitiesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://turkiyeapi.dev/api/v1/provinces");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);
                var items = rootObject.data.Select(x => new CityVM
                {
                    id = x.id,
                    name = x.name
                }).ToList();

                List<SelectListItem> itemList = (from item in items
                                                 select new SelectListItem
                                                 {
                                                     Text = item.name,
                                                     Value = item.id.ToString()
                                                 }).ToList();

                ViewBag.Cities = itemList;
            }
            return View();
        }
    }
}
