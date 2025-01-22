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
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<Testimonial> TGetByIdAsync(int id) => await _testimonialDal.GetByIdAsync(id);

        public async Task<IEnumerable<Testimonial>> TGetListAsync() => await _testimonialDal.GetListAsync();

        public async Task<IEnumerable<Testimonial>> TGetListAsync(Expression<Func<Testimonial, bool>> filter) => await _testimonialDal.GetListAsync(filter);

        public async Task TDelete(Testimonial entity) => await _testimonialDal.Delete(entity);

        public async Task TInsertAsync(Testimonial entity) => await _testimonialDal.InsertAsync(entity);

        public async Task TUpdate(Testimonial entity) => await _testimonialDal.Update(entity);
    }
}
