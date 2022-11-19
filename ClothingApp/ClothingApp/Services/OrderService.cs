using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly SendRequestAPI sendRequestAPI = new SendRequestAPI();
        async public Task<ApiResponse> CreateOrder(CreateOrderModel createOrderModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/Order", createOrderModel);

            return apiResponse;
        }

        async public Task<ApiResponse> DeleteOrder(DeleteOrderModel deleteOrderModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.DeleteRequest("api/Order", deleteOrderModel);

            return apiResponse;
        }

        async public Task<ApiResponse> EditOrder(EditOrderModel editOrderModel)
        {
            return await sendRequestAPI.PutRequest("api/Order", editOrderModel);
        }

        async public Task<ApiResponse> GetAllOrderByUserId(string userId)
        {
            return await sendRequestAPI.GetRequest($"api/Order/User/{userId}");
        }

        async public Task<ApiResponse> GetAllOrders()
        {
            return await sendRequestAPI.GetRequest("api/Order");
        }

        async public Task<ApiResponse> GetAllProductByOrderId(string orderId)
        {
            return await sendRequestAPI.GetRequest($"api/Order/{orderId}");
        }

        async public Task<ApiResponse> UpdateStatus(UpdateStatusOrderModel updateStatusOrderModel)
        {
            return await sendRequestAPI.PutRequest("api/Order/Status", updateStatusOrderModel);
        }
    }
}
