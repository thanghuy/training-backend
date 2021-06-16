using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Models.DTOs
{
    public class CartDTO : Product
    {
        public int IdCart { get; set; }
        public int IdUser { get; set; }
        public int Amount { get; set; }
        public decimal? Price_item { get; set; }
    }
}
