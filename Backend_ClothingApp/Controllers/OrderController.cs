using Backend_ClothingApp.Data;
using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models.OrderModel;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                List<OrderVM> orderVMs = _orderRepository.GetAllOrders();

                return Ok(new ApiResponse(true, orderVMs));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }
        [HttpGet("User/{userId}")]
        public IActionResult GetAllOrderByUserId(string userId)
        {
            try
            {
                List<OrderVM> orderVMs = _orderRepository.GetAllOrderByUserId(userId);

                return Ok(new ApiResponse(true, orderVMs));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderByOrderId(string orderId)
        {
            OrderVM orderVM = _orderRepository.GetOrderByOrderId(orderId);

            if (orderVM == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy đơn hàng này"));
            }

            return Ok(new ApiResponse(true, orderVM));
        }

        [HttpPost]
        public IActionResult CreateOrder(AddOrderModel addOrderModel)
        {
            try
            {
                OrderVM orderVM = _orderRepository.CreateOrder(addOrderModel);

                return Ok(new ApiResponse(true, orderVM));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderModel updateOrderModel)
        {
            try
            {
                bool check = _orderRepository.UpdateOrder(updateOrderModel);

                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy đơn hàng này"));
                }

                return Ok(new ApiResponse(true, "Cập nhật thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
           
        }

        [HttpPut("Status")]
        public IActionResult UpdateOrderStatus(UpdateOrderStatusModel updateOrderStatusModel)
        {
            try
            {
                bool check = _orderRepository.UpdateOrderStatus(updateOrderStatusModel);

                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy đơn hàng này"));
                }

                return Ok(new ApiResponse(true, "Cập nhật thành công"));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrder(DeleteOrderModel deleteOrderModel) {
            try
            {
                bool check = _orderRepository.DeleteOrder(deleteOrderModel);

                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy đơn hàng này"));
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
