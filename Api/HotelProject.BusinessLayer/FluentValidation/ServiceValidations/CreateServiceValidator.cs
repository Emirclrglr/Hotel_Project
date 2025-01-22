using FluentValidation;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.FluentValidation.ServiceValidations
{
    public class CreateServiceValidator:AbstractValidator<CreateServiceDto>
    {
        public CreateServiceValidator()
        {
            RuleFor(x=>x.ServiceTitle).NotEmpty().WithMessage("Hizmet Başlığı Boş Geçilemez.")
                                      .MinimumLength(2).WithMessage("Hizmet Başlığı En Az 2 Karakter İçermelidir.");
            RuleFor(x=>x.ServiceIcon).NotEmpty().WithMessage("Hizmet Simgesi Boş Geçilemez.");
            RuleFor(x=>x.ServiceDescription).NotEmpty().WithMessage("Hizmet Açıklaması Boş Geçilemez.");
        }
    }
}
