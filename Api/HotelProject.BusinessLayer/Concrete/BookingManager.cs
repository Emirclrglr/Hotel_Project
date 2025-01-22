using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TApproveReservation(int id)
        {
            _bookingDal.ApproveReservation(id);
        }

        public int TBookingCount()
        {
            return _bookingDal.BookingCount();
        }

        public async Task<IEnumerable<ResultBookingWithRelationDto>> TBookingListWithRelationAsync()
        {
            return await _bookingDal.BookingListWithRelationAsync();
        }

        public async Task<ResultBookingWithRelationDto> TBookingListWithRelationWithIdAsync(int id)
        {
            return await _bookingDal.BookingListWithRelationWithIdAsync(id);
        }

        public async Task TDelete(Booking entity)
        {
            await _bookingDal.Delete(entity);
        }

        public void TDenyReservation(int id)
        {
            _bookingDal.DenyReservation(id);
        }

        public async Task<Booking> TGetByIdAsync(int id)
        {
            return await _bookingDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Booking>> TGetLast6BookingAsync()
        {
            return await _bookingDal.GetLast6BookingAsync();
        }

        public async Task<IEnumerable<Booking>> TGetListAsync()
        {
            return await _bookingDal.GetListAsync();
        }

        public async Task<IEnumerable<Booking>> TGetListAsync(Expression<Func<Booking, bool>> filter)
        {
            return await _bookingDal.GetListAsync(filter);
        }

        public void THoldReservation(int id)
        {
            _bookingDal.HoldReservation(id);
        }

        public async Task TInsertAsync(Booking entity)
        {
            await _bookingDal.InsertAsync(entity);
        }

        public async Task TUpdate(Booking entity)
        {
            await _bookingDal.Update(entity);
        }
    }
}
