﻿namespace HotelProject.WebUI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int? RoomId { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
