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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task TDelete(Contact entity)
        {
            await _contactDal.Delete(entity);
        }

        public async Task<Contact> TGetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public int TGetContactCount()
        {
            return _contactDal.GetContactCount();
        }

        public async Task<IEnumerable<Contact>> TGetListAsync()
        {
            return await _contactDal.GetListAsync();
        }

        public async Task<IEnumerable<Contact>> TGetListAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _contactDal.GetListAsync(filter);
        }

        public async Task TInsertAsync(Contact entity)
        {
            await _contactDal.InsertAsync(entity);
        }

        public async Task TUpdate(Contact entity)
        {
            await _contactDal.Update(entity);
        }
    }
}
