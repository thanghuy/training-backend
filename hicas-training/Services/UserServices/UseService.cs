using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Models.DTOs;
using hicas_training.Token;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hicas_training.Services.UserServices
{
    public class UseService : DbServices, IUser
    {
        private readonly TokenGenerator _tokenGenerator;

        public UseService(DbContextTraining context, Token.TokenGenerator tokenGenerator) : base(context)
        {
            _tokenGenerator = tokenGenerator;
        }

        public async Task<User> GetInfoUser(int idUser)
        {
            return await _context.Users.FindAsync(idUser);
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
                String token = _tokenGenerator.GenerateToken(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("id",user.IdUser.ToString()),
                new Claim("username",user.Name),
                new Claim(ClaimTypes.Role, "Admin"),
            });
                userTest.Token = token;

            }
            return userTest;

        }

        public async Task<User> Register(User user)
        {
            var result = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (result is not null)
            {
                return null;
            }
            else
            {
                _context.Add(user);
            }
            int isUser = await _context.SaveChangesAsync();
            if (isUser == 0)
            {
                return null;
            }
            return user;
        }
    }
}
