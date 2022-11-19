using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models.CartModel;
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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(string userId)
        {
            try
            {
                CartVM cartVM = _cartRepository.GetByUserId(userId);

                if(cartVM == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy giỏ hàng này"));
                }

                return Ok(new ApiResponse(true, cartVM));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Create(AddCartModel addCartModel)
        {
            try
            {
                CartVM cartVM = _cartRepository.Create(addCartModel);

                if(cartVM == null)
                {
                    return StatusCode(StatusCodes.Status302Found, new ApiResponse(false, "Người dùng này đã có giỏ hàng"));
                }
                return Ok(new ApiResponse(true, cartVM));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }
    }
}
