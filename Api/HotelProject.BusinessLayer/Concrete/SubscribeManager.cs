using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager:ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public async Task<Subscribe> TGetByIdAsync(int id) => await _subscribeDal.GetByIdAsync(id);

        public async Task<IEnumerable<Subscribe>> TGetListAsync() => await _subscribeDal.GetListAsync();

        public async Task<IEnumerable<Subscribe>> TGetListAsync(Expression<Func<Subscribe, bool>> filter) => await _subscribeDal.GetListAsync(filter);

        public async Task TDelete(Subscribe entity) => await _subscribeDal.Delete(entity);

        public async Task TInsertAsync(Subscribe entity) => await _subscribeDal.InsertAsync(entity);

        public async Task TUpdate(Subscribe entity) => await _subscribeDal.Update(entity);

        public int TSubscriberCount() => _subscribeDal.SubscriberCount();

    }
}
