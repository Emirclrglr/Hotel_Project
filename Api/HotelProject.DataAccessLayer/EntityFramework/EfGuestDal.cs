using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfGuestDal : GenericRepository<Guest>, IGuestDal
    {
        private readonly Context _context;
        public EfGuestDal(Context context) : base(context)
        {
            _context = context;
        }

        public int TotalGuestCount()
        {
            return _context.Guests.Select(x => x.TotalGuests).FirstOrDefault();
        }
    }
}
