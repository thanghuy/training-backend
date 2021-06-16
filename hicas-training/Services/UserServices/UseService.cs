using hicas_training.Data;
using hicas_training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.UserServices
{
    public class UseService : DbServices, IUser
    {
        public UseService(DbContextTraining context) : base(context)
        {
        }

        public Task<User> GetInfoUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
