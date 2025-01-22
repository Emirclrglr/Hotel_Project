using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.StaffDtos
{
    public class UpdateStaffDto
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string XUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
