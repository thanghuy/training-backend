using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Models
{
    public class Cart
    {
        public int IdCart { get; set; }
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
    }
}
