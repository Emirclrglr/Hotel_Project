using FluentValidation;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.FluentValidation.RoomValidations
{
    public class UpdateRoomValidator:AbstractValidator<UpdateRoomDto>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.RoomTitle).NotEmpty().WithMessage("Oda Başlığı Boş Geçilemez");
            RuleFor(x => x.RoomNumber).NotEmpty().WithMessage("Oda Numarası Boş Geçilemez");
            RuleFor(x => x.BedCount).NotEmpty().WithMessage("Oda Yatak Sayısı Boş Geçilemez");
            RuleFor(x => x.BathCount).NotEmpty().WithMessage("Oda Banyo Sayısı Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Oda Fiyat Bilgisi Boş Geçilemez");
            RuleFor(x => x.RoomCoverImg).NotEmpty().WithMessage("Oda Görseli Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Oda Açıklaması Boş Geçilemez");

        }
    }
}
