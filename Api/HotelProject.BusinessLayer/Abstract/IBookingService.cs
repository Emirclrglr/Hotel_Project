using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TApproveReservation(int id);
        void TDenyReservation(int id);
        void THoldReservation(int id);
        Task<IEnumerable<ResultBookingWithRelationDto>> TBookingListWithRelationAsync();
        Task<ResultBookingWithRelationDto> TBookingListWithRelationWithIdAsync(int id);
        Task<IEnumerable<Booking>> TGetLast6BookingAsync();
        int TBookingCount();
    }
}
