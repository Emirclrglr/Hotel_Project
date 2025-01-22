using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AppUserDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public Task TDelete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> TGetListAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultAppUserWithRelationDto>> TUserListWithWorkLocation()
        {
            return await _appUserDal.UserListWithWorkLocation();
        }
    }
}
