using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager:IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<Service> TGetByIdAsync(int id) => await _serviceDal.GetByIdAsync(id);

        public async Task<IEnumerable<Service>> TGetListAsync() => await _serviceDal.GetListAsync();

        public async Task<IEnumerable<Service>> TGetListAsync(Expression<Func<Service, bool>> filter) => await _serviceDal.GetListAsync(filter);

        public async Task TDelete(Service entity) => await _serviceDal.Delete(entity);

        public async Task TInsertAsync(Service entity) => await _serviceDal.InsertAsync(entity);

        public async Task TUpdate(Service entity) => await _serviceDal.Update(entity);
    }
}
