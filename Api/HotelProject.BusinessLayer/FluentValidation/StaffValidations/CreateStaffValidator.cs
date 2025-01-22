using FluentValidation;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.FluentValidation.StaffValidations
{
    public class CreateStaffValidator:AbstractValidator<CreateStaffDto>
    {
        public CreateStaffValidator()
        {
            RuleFor(x => x.StaffTitle).NotEmpty().WithMessage("Personel Unvanı Boş Geçilemez.");
            RuleFor(x => x.StaffName).NotEmpty().WithMessage("Personel Adı Soyadı Boş Geçilemez.");
            RuleFor(x => x.StaffImageUrl).NotEmpty().WithMessage("Personel Görseli Boş Geçilemez.");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Personel Instagram Adresi Boş Geçilemez.");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Personel Facebook Adresi Boş Geçilemez.");
            RuleFor(x => x.XUrl).NotEmpty().WithMessage("Personel X Adresi Boş Geçilemez.");
        }
    }
}
