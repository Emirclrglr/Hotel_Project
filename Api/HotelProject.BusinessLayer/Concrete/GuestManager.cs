using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }

        public Task TDelete(Guest entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> TGetListAsync(Expression<Func<Guest, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Guest entity)
        {
            throw new NotImplementedException();
        }

        public int TotalGuestCount()
        {
            return _guestDal.TotalGuestCount();
        }

        public Task TUpdate(Guest entity)
        {
            throw new NotImplementedException();
        }
    }
}
