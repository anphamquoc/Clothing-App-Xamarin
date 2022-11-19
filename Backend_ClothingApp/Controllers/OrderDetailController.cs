using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models.OrderDetailModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_ClothingApp.Services;

namespace Backend_ClothingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRespository _orderDetailRepository;
        public OrderDetailController(IOrderDetailRespository orderDetailRespository) {
            _orderDetailRepository = orderDetailRespository;
        }
        [HttpGet("{orderId}")]
        public IActionResult GetOrderDetailsByOrderId(string orderId)
        {
            try
            {
                List<OrderDetailVM> orderDetailVMs = _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
                return Ok(new ApiResponse(true, orderDetailVMs));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(AddOrderDetailModel addOrderDetailModel) {
            try
            {
                bool check = _orderDetailRepository.CreateOrderDetail(addOrderDetailModel);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status302Found, new ApiResponse(false, "Sản phẩm này đã có trong đơn hàng"));
                }

                return Ok(new ApiResponse(true, "Thêm thành công"));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult UpdateOrderDetailQuantity(UpdateOrderDetailModel updateOrderDetailModel)
        {
            try
            {
                bool check = _orderDetailRepository.UpdateOrderDetailQuantity(updateOrderDetailModel);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm trong đơn hàng"));
                }

                return Ok(new ApiResponse(true, "Cập nhật thành công"));
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrderDetail(DeleteOrderDetailModel deleteOrderDetailModel)
        {
            try
            {
                bool check = _orderDetailRepository.DeleteOrderDetail(deleteOrderDetailModel);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm"));
                }

                return Ok(new ApiResponse(true, "Xóa thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }
    }
}
