using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.WebUI.Dtos.RegisterDtos
{
    public class RegisterDto
    {
        public string cityName { get; set; }
        public string WorkLocationName { get; set; }
        public int WorkLocationId { get; set; }

        [Required(ErrorMessage ="Ad Gereklidir.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Soyad Gereklidir.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email Gereklidir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Gereklidir.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifrelerin Eşleştiğinden Emin Olunuz.")]
        [Required(ErrorMessage = "Şifre Doğrulama Gereklidir.")]
        public string ConfirmPassword { get; set; }
    }
}
