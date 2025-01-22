﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.RoomDtos
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public string RoomTitle { get; set; }
        public string RoomCoverImg { get; set; }
        public decimal Price { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }

    }
}
