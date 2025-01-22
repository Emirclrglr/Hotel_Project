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
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public async Task TDelete(WorkLocation entity)
        {
            await _workLocationDal.Delete(entity);
        }

        public async Task<WorkLocation> TGetByIdAsync(int id)
        {
            return await _workLocationDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<WorkLocation>> TGetListAsync()
        {
            return await _workLocationDal.GetListAsync();
        }

        public async Task<IEnumerable<WorkLocation>> TGetListAsync(Expression<Func<WorkLocation, bool>> filter)
        {
            return await _workLocationDal.GetListAsync(filter);
        }

        public async Task TInsertAsync(WorkLocation entity)
        {
            await _workLocationDal.InsertAsync(entity);
        }

        public async Task TUpdate(WorkLocation entity)
        {
            await _workLocationDal.Update(entity);
        }
    }
}
