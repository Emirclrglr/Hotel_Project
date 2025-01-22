namespace HotelProject.WebUI.ApiService
{
    public class ApiSettings : IApiSettings
    {
        private readonly IConfiguration _config;
        private readonly string? _apiUrl;
        public ApiSettings(IConfiguration config)
        {
            _config = config;
            _apiUrl = _config.GetSection("ApiSettings")["BaseUrl"];
        }

        public string BaseUrl => _apiUrl;
    }
}
