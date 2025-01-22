using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetLast4Staff()
        {
            return await _context.Staffs.Take(4).OrderByDescending(x => x.StaffId).ToListAsync();
        }

        public int TotalStaffCount()
        {
            return _context.Staffs.Count();
        }
    }
}
