using ClothingApp.Helpers;
using ClothingApp.Model;
using ClothingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<ApiResponse> GetAllOrderDetailByOrderId(string orderId);
        Task<ApiResponse> AddProductToOrder(AddProductToOrderModel addProductToOrderModel);
        Task<ApiResponse> UpdateQuantityOrderDetail(UpdateQuantityOrderModel updateQuantityOrderModel);
        Task<ApiResponse> DeleteProductFromOrder(DeleteOrderDetailModel deleteOrderDetailModel);
    }
}
