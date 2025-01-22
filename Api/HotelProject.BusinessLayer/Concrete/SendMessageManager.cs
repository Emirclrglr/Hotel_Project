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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public async Task TDelete(SendMessage entity)
        {
            await _sendMessageDal.Delete(entity);
        }

        public async Task<SendMessage> TGetByIdAsync(int id)
        {
            return await _sendMessageDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SendMessage>> TGetListAsync()
        {
            return await _sendMessageDal.GetListAsync();
        }

        public async Task<IEnumerable<SendMessage>> TGetListAsync(Expression<Func<SendMessage, bool>> filter)
        {
            return await _sendMessageDal.GetListAsync(filter);
        }

        public async Task TInsertAsync(SendMessage entity)
        {
            await _sendMessageDal.InsertAsync(entity);
        }

        public int TSentMessageCount()
        {
            return _sendMessageDal.SentMessageCount();
        }

        public async Task TUpdate(SendMessage entity)
        {
            await _sendMessageDal.Update(entity);
        }
    }
}
