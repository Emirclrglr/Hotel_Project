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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public async Task<Room> TGetByIdAsync(int id) => await _roomDal.GetByIdAsync(id);

        public async Task<IEnumerable<Room>> TGetListAsync() => await _roomDal.GetListAsync();
        
        public async Task<IEnumerable<Room>> TGetListAsync(Expression<Func<Room, bool>> filter) => await _roomDal.GetListAsync(filter);

        public async Task TDelete(Room entity) => await _roomDal.Delete(entity);

        public async Task TInsertAsync(Room entity) => await _roomDal.InsertAsync(entity);

        public async Task TUpdate(Room entity) => await _roomDal.Update(entity);

        public async Task<IEnumerable<Room>> TGetLast3Rooms()
        {
            return await _roomDal.GetLast3Rooms();  
        }
    }
}
