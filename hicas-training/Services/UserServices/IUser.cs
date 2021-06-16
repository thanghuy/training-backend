using hicas_training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.UserServices
{
    public interface IUser
    {
        public Task<User> GetInfoUser(int idUser);
        public Task<Boolean> Login(User user); 
    }
}
