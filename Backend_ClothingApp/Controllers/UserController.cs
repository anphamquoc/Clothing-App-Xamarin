using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models;
using Backend_ClothingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(new ApiResponse(true, _userRepository.GetAll()));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                UserVM userVM = _userRepository.GetById(id);
                if (userVM == null)
                {
                    return NotFound(new ApiResponse(false, "Không tìm thấy người dùng"));
                }

                return Ok(new ApiResponse(true, userVM));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                UserVM userVM = _userRepository.Login(loginModel);

                if(userVM == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Sai tài khoản hoặc mật khẩu"));
                }

                return Ok(new ApiResponse(true, userVM));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel registerModel)
        {
            try
            {
                UserVM userVM = _userRepository.Register(registerModel);
                if(userVM == null)
                {
                    return StatusCode(StatusCodes.Status302Found, new ApiResponse(false, "Đã có người dùng với tài khoản này"));
                }

                return Ok(new ApiResponse(true, userVM));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(string userId, UpdateUserModel updateUserModel)
        {
            try
            {
                bool check = _userRepository.Update(userId, updateUserModel);
                if(!check)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse(false, "Update thất bại"));
                }

                return Ok(new ApiResponse(true, "Update thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut("ChangePassword/{userId}")]
        public IActionResult UpdatePassword(string userId, ChangePasswordUserModel changePasswordUserModel)
        {
            try
            {
                bool check = _userRepository.ChangePassword(userId, changePasswordUserModel);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse(false, "Mật khẩu sai"));
                }

                return Ok(new ApiResponse(true, "Đổi mật khẩu thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                bool check = _userRepository.Delete(userId);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy người dùng"));
                }

                return Ok(new ApiResponse(true, "Xóa thành công"));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }
    }
}
