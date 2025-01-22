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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task TDelete(About entity)
        {
            await _aboutDal.Delete(entity);
        }

        public async Task<About> TGetByIdAsync(int id)
        {
            return await _aboutDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<About>> TGetListAsync()
        {
            return await _aboutDal.GetListAsync();
        }

        public async Task<IEnumerable<About>> TGetListAsync(Expression<Func<About, bool>> filter)
        {
            return await _aboutDal.GetListAsync(filter);
        }

        public async Task TInsertAsync(About entity)
        {
            await _aboutDal.InsertAsync(entity);
        }

        public async Task TUpdate(About entity)
        {
            await _aboutDal.Update(entity);
        }
    }
}
