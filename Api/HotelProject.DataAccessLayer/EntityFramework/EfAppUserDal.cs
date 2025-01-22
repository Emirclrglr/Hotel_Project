using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.DtoLayer.Dtos.AppUserDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;
        public EfAppUserDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultAppUserWithRelationDto>> UserListWithWorkLocation()
        {
            var values = await _context.Users.Select(x=>new ResultAppUserWithRelationDto
            {
                Firstname = x.Firstname,
                City = x.City,
                Email = x.Email,
                Lastname = x.Lastname,
                UserName = x.UserName,
                WorkLocationName = x.WorkLocation.WorkLocationName,
                WorkLocationCity = x.WorkLocation.WorkLocationCity
            }).ToListAsync();
            return values;
        }
    }
}
