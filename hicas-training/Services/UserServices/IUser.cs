using hicas_training.Models;
using hicas_training.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services.UserServices
{
    public interface IUser
    {
        public Task<User> GetInfoUser(int idUser);
        public Task<UserResultDTO> DoLogin(string username, string password); 
    }
}
