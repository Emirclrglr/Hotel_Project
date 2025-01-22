using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Gereklidir.")]
        public string Password { get; set; }
    }
}
