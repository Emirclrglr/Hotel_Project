using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IStaffDal:IGenericDal<Staff>
    {
        int TotalStaffCount();
        Task<IEnumerable<Staff>> GetLast4Staff();
    }
}
