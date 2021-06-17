using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Models.DTOs
{
    public class FilterDTO
    {
        public string? KeyWord { get; set; } = "";
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? RateFrom { get; set; } = 0;
         public int? RateTo { get; set; } = 0;
    }
}
