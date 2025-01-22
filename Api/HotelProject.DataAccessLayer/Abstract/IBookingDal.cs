using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void ApproveReservation(int id);
        void DenyReservation(int id);
        void HoldReservation(int id);
        Task<IEnumerable<ResultBookingWithRelationDto>> BookingListWithRelationAsync();
        Task<ResultBookingWithRelationDto> BookingListWithRelationWithIdAsync(int id);
        Task<IEnumerable<Booking>> GetLast6BookingAsync();
        int BookingCount();
    }
}
