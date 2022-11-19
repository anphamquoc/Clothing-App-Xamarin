using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models.CartDetailModel;
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
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailRepository _cartDetailRepository;
        public CartDetailController(ICartDetailRepository cartDetailRepository)
        {
            _cartDetailRepository = cartDetailRepository;
        }

        [HttpGet("{cartId}")]
        public IActionResult GetAllCartDetailByCartId(string cartId)
        {
            try
            {
                List<CartDetailVM> cartDetailVMs = _cartDetailRepository.GetAllCartDetailByCartId(cartId);

                return Ok(new ApiResponse(true, cartDetailVMs));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult AddCartDetail(AddCartDetail addCartDetail)
        {
            try
            {
                CartDetailVM cartDetailVM = _cartDetailRepository.AddCartDetail(addCartDetail);

                if(cartDetailVM == null)
                {
                    return StatusCode(StatusCodes.Status302Found, new ApiResponse(false, "Sản phẩm này đã có trong giỏ hàng"));
                }

                return Ok(new ApiResponse(true, "Thêm vào giỏ hàng thành công"));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult UpdateCartDetailQuantity(UpdateCartDetail updateCartDetail) {
            try
            {
                bool check = _cartDetailRepository.UpdateQuantity(updateCartDetail);

                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm trong giỏ hàng"));
                }

                return Ok(new ApiResponse(true, "Thay đổi số lượng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult DeleteCartDetail(DeleteCartDetail deleteCartDetail)
        {
            try
            {
                bool check = _cartDetailRepository.DeleteCartDetail(deleteCartDetail);

                if(!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm trong giỏ hàng"));
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
