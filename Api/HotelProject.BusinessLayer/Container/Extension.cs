using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.BusinessLayer.FluentValidation.AboutValidations;
using HotelProject.BusinessLayer.FluentValidation.RoomValidations;
using HotelProject.BusinessLayer.FluentValidation.ServiceValidations;
using HotelProject.BusinessLayer.FluentValidation.StaffValidations;
using HotelProject.BusinessLayer.FluentValidation.SubscribeValidations;
using HotelProject.BusinessLayer.FluentValidation.TestimonialValidations;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Container
{
    public static class Extension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddDbContext<Context>();

            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<IGuestDal, EfGuestDal>();
            services.AddScoped<IGuestService, GuestManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            services.AddScoped<ISendMessageService, SendMessageManager>();

            services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            services.AddScoped<IWorkLocationService, WorkLocationManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddValidatorsFromAssemblyContaining<CreateRoomValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateRoomValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateServiceValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateServiceValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateTestimonialValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateTestimonialValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateStaffValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateStaffValidator>();

            services.AddValidatorsFromAssemblyContaining<UpdateSubscribeValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateAboutValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAboutValidator>();
        }
    }
}
