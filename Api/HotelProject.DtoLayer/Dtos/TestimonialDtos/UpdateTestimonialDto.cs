﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImageUrl { get; set; }

    }
}
