using AutoMapper;
using HotelProject.DtoLayer.Dtos.AboutDtos;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.DtoLayer.Dtos.SubscribeDtos;
using HotelProject.DtoLayer.Dtos.TestimonialDtos;
using HotelProject.DtoLayer.Dtos.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();

            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDto>().ReverseMap();

            CreateMap<Staff, CreateStaffDto>().ReverseMap();
            CreateMap<Staff, UpdateStaffDto>().ReverseMap();

            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            CreateMap<WorkLocation, CreateWorkLocationDto>().ReverseMap();
            CreateMap<WorkLocation, UpdateWorkLocationDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();

            CreateMap<SendMessage, CreateSendMessageDto>().ReverseMap();

            
        }
    }
}
