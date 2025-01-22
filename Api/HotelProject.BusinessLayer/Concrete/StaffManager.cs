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
    public class StaffManager:IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task<Staff> TGetByIdAsync(int id) => await _staffDal.GetByIdAsync(id);

        public async Task<IEnumerable<Staff>> TGetListAsync() => await _staffDal.GetListAsync();

        public async Task<IEnumerable<Staff>> TGetListAsync(Expression<Func<Staff, bool>> filter) => await _staffDal.GetListAsync(filter);

        public async Task TDelete(Staff entity) => await _staffDal.Delete(entity);

        public async Task TInsertAsync(Staff entity) => await _staffDal.InsertAsync(entity);

        public async Task TUpdate(Staff entity) => await _staffDal.Update(entity);

        public int TTotalStaffCount() => _staffDal.TotalStaffCount();

        public async Task<IEnumerable<Staff>> TGetLast4Staff() => await _staffDal.GetLast4Staff();

    }
}
