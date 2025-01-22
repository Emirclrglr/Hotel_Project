using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DtoLayer.Dtos.AppUserDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        Task<IEnumerable<ResultAppUserWithRelationDto>> UserListWithWorkLocation();
    }
}
