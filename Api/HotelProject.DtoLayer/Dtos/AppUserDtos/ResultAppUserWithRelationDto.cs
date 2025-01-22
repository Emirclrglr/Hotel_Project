using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.AppUserDtos
{
    public class ResultAppUserWithRelationDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string? City { get; set; }
        public string Email { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }

    }
}
