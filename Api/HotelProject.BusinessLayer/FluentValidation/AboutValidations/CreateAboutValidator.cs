using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelProject.DtoLayer.Dtos.AboutDtos;

namespace HotelProject.BusinessLayer.FluentValidation.AboutValidations
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x=>x.Title1).NotEmpty().WithMessage("Başlık 1 Kısmı Boş Geçilemez.");
            RuleFor(x=>x.Title2).NotEmpty().WithMessage("Başlık 2 Kısmı Boş Geçilemez.");
            RuleFor(x=>x.AboutContent).NotEmpty().WithMessage("Hakkımızda Açıklaması Kısmı Boş Geçilemez.");
        }
    }
}
