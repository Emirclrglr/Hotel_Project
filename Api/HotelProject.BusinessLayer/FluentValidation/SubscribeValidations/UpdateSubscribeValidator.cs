using FluentValidation;
using HotelProject.DtoLayer.Dtos.SubscribeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.FluentValidation.SubscribeValidations
{
    public class UpdateSubscribeValidator:AbstractValidator<UpdateSubscribeDto>
    {
        public UpdateSubscribeValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email Boş Geçilemez.");
        }
    }
}
