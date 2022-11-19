using ClothingApp.Helpers;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface IOrderRepository
    {
        Task<ApiResponse> GetAllOrders();
        Task<ApiResponse> GetAllOrderByUserId(string userId);
        Task<ApiResponse> GetAllProductByOrderId(string orderId);
        Task<ApiResponse> CreateOrder(CreateOrderModel createOrderModel);
        Task<ApiResponse> UpdateStatus(UpdateStatusOrderModel updateStatusOrderModel);
        Task<ApiResponse> EditOrder(EditOrderModel editOrderModel);
        Task<ApiResponse> DeleteOrder(DeleteOrderModel deleteOrderModel);
    }
}
