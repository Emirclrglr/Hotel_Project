using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.WorkLocationDtos
{
    public class UpdateWorkLocationDto
    {
        public int WorkLocationId { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }
    }
}
