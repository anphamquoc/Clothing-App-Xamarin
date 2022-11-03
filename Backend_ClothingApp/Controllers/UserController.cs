using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_ClothingApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_ClothingApp.Models;
using Backend_ClothingApp.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Backend_ClothingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SecurePasswordHasher securePasswordHasher = new SecurePasswordHasher();
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _context.Users.ToList();
            return Ok(new ApiResponse { 
                Success = true,
                Data = users
            });
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
                User user = _context.Users.SingleOrDefault(user => user.Username == userBody.Username);

                if(user == null)
                {
                    return NotFound(new { 
                        Success = false,
                        Message = "Sai tài khoản"
                    });
                }

                if (!securePasswordHasher.Verify(userBody.Password, user.Password))
                {
                    return StatusCode(StatusCodes.Status404NotFound ,new
                    {
                        Success = false,
                        Message = "Sai mật khẩu"
                    });
                }

                return Ok(new { 
                    Success = true,
                    Data = user
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiResponse {
                    Success = false,
                    Message = ex.Message
                });
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
                    return BadRequest(new ApiResponse
                    {
                        Success = true,
                        Message = "Đã có người dùng với tên đăng nhập này"
                    });
                }

                string hashPassword = securePasswordHasher.Hash(userBody.Password);

                user = new User {
                    Username = userBody.Username,
                    Password = hashPassword
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(new {
                    Success = true,
                    Data = user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse{ 
                    Success = false,
                    Message = ex.Message
                });
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
                    return BadRequest(new ApiResponse {
                        Success = false,
                        Message = $"Không có user với id={id} này"
                    });
                }

                user.PhoneNumber = userBody.PhoneNumber;
                user.Address = userBody.Address;
                user.Email = userBody.Email;

                _context.SaveChanges();

                return Ok(new ApiResponse
                { 
                    Success = true,
                    Data = user
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
