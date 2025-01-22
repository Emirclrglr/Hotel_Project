using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public void ApproveReservation(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "Onaylandı";
                _context.SaveChanges();
            }
        }

        public int BookingCount()
        {
            return _context.Bookings.Count();
        }

        public async Task<IEnumerable<ResultBookingWithRelationDto>> BookingListWithRelationAsync()
        {
            var values = await _context.Bookings.Select(x => new ResultBookingWithRelationDto
            {
                Name = x.Name,
                AdultCount = x.AdultCount,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                ChildCount = x.ChildCount,
                Description = x.Description,
                Id = x.Id,
                Mail = x.Mail,
                RoomTitle = x.Rooms.RoomTitle,
                SpecialRequest = x.SpecialRequest,
                Status = x.Status

            }).ToListAsync();

            return values;
        }

        public async Task<ResultBookingWithRelationDto> BookingListWithRelationWithIdAsync(int id)
        {
            var values = await _context.Bookings.Select(x => new ResultBookingWithRelationDto
            {
                Id = id,
                Name = x.Name,
                AdultCount = x.AdultCount,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                ChildCount = x.ChildCount,
                Description = x.Description,
                Mail = x.Mail,
                RoomTitle = x.Rooms.RoomTitle,
                SpecialRequest = x.SpecialRequest,
                Status = x.Status
            }).Where(y => y.Id == id).FirstOrDefaultAsync();
            return values;
        }

        public void DenyReservation(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "İptal Edildi";
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Booking>> GetLast6BookingAsync()
        {
            return await _context.Bookings.Take(6).OrderByDescending(x => x.Id).ToListAsync();
        }

        public void HoldReservation(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "Onay Bekliyor";
                _context.SaveChanges();
            }
        }
    }
}
