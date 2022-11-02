using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_ClothingApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_ClothingApp.Models;

namespace Backend_ClothingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            User user = _context.Users.ToList().SingleOrDefault(user => user.id == Guid.Parse(id));

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel userBody)
        {
            try
            {
                User user = _context.Users.SingleOrDefault(user => user.Username == userBody.Username && user.Password == userBody.Password);

                if(user == null)
                {
                    return NotFound("Sai tài khoản hoặc mật khẩu");
                }

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel userBody)
        {
            try
            {
                User user = _context.Users.SingleOrDefault(user => user.Username == userBody.Username);

                if (user != null)
                {
                    return BadRequest("Đã có người dùng với tên đăng nhập này");
                }

                user = new User{
                    Username = userBody.Username,
                    Password = userBody.Password
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(userBody);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateUserById(string id, UpdateUserModel userBody)
        {
            try
            {
                User user = _context.Users.ToList().SingleOrDefault(user => user.id.ToString() == id);

                if (user == null)
                {
                    return BadRequest($"Không có user với id={id} này");
                }

                Console.WriteLine(1);

                user.PhoneNumber = userBody.PhoneNumber;
                user.Address = userBody.Address;
                user.Email = userBody.Email;

                _context.SaveChanges();

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
