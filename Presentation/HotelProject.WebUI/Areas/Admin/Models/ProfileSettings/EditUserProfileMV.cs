using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Models.ProfileSettings
{
    public class EditUserProfileMV
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
