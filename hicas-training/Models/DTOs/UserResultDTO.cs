using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Models.DTOs
{
    public class UserResultDTO
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public string AddressCompany { get; set; }
        public string AddressHome { get; set; }
        public string Token { get; set; }
    }
}
