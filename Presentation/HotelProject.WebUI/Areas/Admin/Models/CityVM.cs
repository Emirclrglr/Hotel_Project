namespace HotelProject.WebUI.Areas.Admin.Models
{
    public class CityVM
    {

        public class RootObject
        {
            public IEnumerable<CityVM> data { get; set; }
        }

        public int id { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public int area { get; set; }
        public int altitude { get; set; }
        public bool isMetropolitan { get; set; }

    }
}
