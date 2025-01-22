using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Booking
{
    public class _BookingPageHeaderViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }    
    }
}
