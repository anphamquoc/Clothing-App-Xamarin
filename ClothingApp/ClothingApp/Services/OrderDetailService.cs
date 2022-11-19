using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    class OrderDetailService : IOrderDetailRepository
    {
        private readonly SendRequestAPI sendRequestAPI = new SendRequestAPI();
        async public Task<ApiResponse> AddProductToOrder(AddProductToOrderModel addProductToOrderModel)
        {
            return await sendRequestAPI.PostRequest("api/OrderDetail", addProductToOrderModel);
        }

        async public Task<ApiResponse> DeleteProductFromOrder(DeleteOrderDetailModel deleteOrderDetailModel)
        {
            return await sendRequestAPI.DeleteRequest("api/OrderDetail", deleteOrderDetailModel);
        }

        async public Task<ApiResponse> GetAllOrderDetailByOrderId(string orderId)
        {
            return await sendRequestAPI.GetRequest($"api/OrderDetail/{orderId}");
        }

        async public Task<ApiResponse> UpdateQuantityOrderDetail(UpdateQuantityOrderModel updateQuantityOrderModel)
        {
            return await sendRequestAPI.PutRequest("api/OrderDetail", updateQuantityOrderModel);
        }

    }
}
