using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsertAsync(T entity);
        Task TDelete(T entity);
        Task TUpdate(T entity);
        Task<IEnumerable<T>> TGetListAsync();
        Task<IEnumerable<T>> TGetListAsync(Expression<Func<T, bool>> filter);
        Task<T> TGetByIdAsync(int id);
    }
}
