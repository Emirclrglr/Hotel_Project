using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Areas.Admin.Models;
using HotelProject.WebUI.Dtos.RegisterDtos;
using HotelProject.WebUI.Dtos.WorkLocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static HotelProject.WebUI.Areas.Admin.Models.CityVM;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly IApiSettings _apiUrl;

        public RegisterController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory, IApiSettings apiUrl)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        private async Task CityList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://turkiyeapi.dev/api/v1/provinces");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);
                var items = rootObject.data.Select(x => new RegisterDto
                {
                    cityName = x.name
                }).ToList();

                List<SelectListItem> itemList = (from item in items
                                                 select new SelectListItem
                                                 {
                                                     Text = item.cityName,
                                                     Value = item.cityName
                                                 }).ToList();

                ViewBag.Cities = itemList;
            }
        }

        private async Task WorkLocationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiUrl.BaseUrl}WorkLocationAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultWorkLocationDto>>(jsonData);
                List<SelectListItem> items = (from item in values.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = item.WorkLocationName,
                                                  Value = item.WorkLocationId.ToString()
                                              }).ToList();

                ViewBag.WorkLocation = items;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await CityList();
            await WorkLocationList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            await CityList();
            await WorkLocationList();
            AppUser user = new()
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                UserName = dto.Username,
                City = dto.cityName,
                WorkLocationId = dto.WorkLocationId,
                WorkDepartment = "test"
            };


            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login", new { area = "Admin" });
            }


            return View(dto);
        }
    }
}
