using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string Subject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }

    }
}
