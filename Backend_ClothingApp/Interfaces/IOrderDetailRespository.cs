using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.OrderDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface IOrderDetailRespository
    {
        public List<OrderDetailVM> GetOrderDetailsByOrderId(string orderId);
        public bool UpdateOrderDetailQuantity(UpdateOrderDetailModel updateOrderDetailModel);
        public bool DeleteOrderDetail(DeleteOrderDetailModel deleteOrderDetailModel);
        public bool CreateOrderDetail(AddOrderDetailModel addOrderDetailModel);
    }
}
