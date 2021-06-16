using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hicas_training.Data;
using hicas_training.Models;
using hicas_training.Services.UserServices;
using hicas_training.Models.DTOs;

namespace hicas_training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DbContextTraining _context;
        private readonly IUser _userService;

        public UsersController(DbContextTraining context, IUser _iUser)
        {
            _context = context;
            _userService = _iUser;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Login(UserLoginDTO customer)
        {

            var result = await _userService.DoLogin(customer.Email, customer.Password);
            if (result.Name == null)
            {
                return Ok(new { status = false, message = "login failed" });
            }
            return Ok(new { status = true, data = result });

        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }
    }
}
