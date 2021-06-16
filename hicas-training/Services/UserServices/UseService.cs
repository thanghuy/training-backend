using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Models.DTOs;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserResultDTO> DoLogin(string username, string password)
        {
            User user = await _context.Users.Where(x => x.Email.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            UserResultDTO userTest = new UserResultDTO();
            if (user != null)
            {
                userTest.IdUser = user.IdUser;
                userTest.Name = user.Name;
                userTest.Email = user.Email;
                userTest.AddressCompany = user.AddressCompany;
                userTest.AddressHome = user.AddressHome;
                userTest.Sex = user.Sex;
                userTest.BirthDate = user.BirthDate;
                
            }
            return userTest;

        }
    }
}
