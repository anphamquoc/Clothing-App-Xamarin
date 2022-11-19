using Backend_ClothingApp.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface IOrderRepository
    {
        List<OrderVM> GetAllOrderByUserId(string userId);
        List<OrderVM> GetAllOrders();
        OrderVM GetOrderByOrderId(string orderId);
        OrderVM CreateOrder(AddOrderModel addOrderModel);
        bool UpdateOrder(UpdateOrderModel updateOrderModel);
        bool DeleteOrder(DeleteOrderModel deleteOrderModel);
        bool UpdateOrderStatus(UpdateOrderStatusModel updateOrderStatusModel);
    }
}
