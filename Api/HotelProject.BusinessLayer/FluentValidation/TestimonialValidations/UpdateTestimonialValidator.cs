using FluentValidation;
using HotelProject.DtoLayer.Dtos.TestimonialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.FluentValidation.TestimonialValidations
{
    public class UpdateTestimonialValidator:AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialValidator()
        {
            RuleFor(x => x.TestimonialName).NotEmpty().WithMessage("Referans Adı Soyadı Boş Geçilemez");
            RuleFor(x => x.TestimonialTitle).NotEmpty().WithMessage("Referans Unvanı Boş Geçilemez");
            RuleFor(x => x.TestimonialComment).NotEmpty().WithMessage("Referans Yorumu Boş Geçilemez");
            RuleFor(x => x.TestimonialImageUrl).NotEmpty().WithMessage("Referans Görseli Boş Geçilemez");
        }
    }
}
