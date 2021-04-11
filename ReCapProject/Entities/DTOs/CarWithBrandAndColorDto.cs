﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarWithBrandAndColorDto : IDto
    {
        public int Id { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public string Name { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
