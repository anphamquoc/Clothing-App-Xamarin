using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.OrderDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class OrderDetailRepository : IOrderDetailRespository
    {
        private readonly MyDbContext _context;
        public OrderDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        public bool CreateOrderDetail(AddOrderDetailModel addOrderDetailModel)
        {
            OrderDetail orderDetail = _context.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == addOrderDetailModel.OrderId && orderDetail.ProductId == addOrderDetailModel.OrderId);
            if (orderDetail != null)
            {
                return false;
            }

            orderDetail = new OrderDetail
            {
                OrderId = addOrderDetailModel.OrderId,
                ProductId = addOrderDetailModel.ProductId,
                Quantity = addOrderDetailModel.Quantity,
            };

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteOrderDetail(DeleteOrderDetailModel deleteOrderDetailModel)
        {
            OrderDetail orderDetail = _context.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == deleteOrderDetailModel.OrderId && orderDetail.ProductId == deleteOrderDetailModel.ProductId);

            if (orderDetail == null)
            {
                return false;
            }

            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();

            return true;
        }

        public List<OrderDetailVM> GetOrderDetailsByOrderId(string orderId)
        {
            List<OrderDetail> orderDetails = _context.OrderDetails.Where(orderDetail => orderDetail.OrderId.ToString() == orderId).ToList();

            return orderDetails.Select(orderDetail => new OrderDetailVM(orderDetail)).ToList();
        }

        public bool UpdateOrderDetailQuantity(UpdateOrderDetailModel updateOrderDetailModel)
        {
            OrderDetail orderDetail = _context.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == updateOrderDetailModel.OrderId && orderDetail.ProductId == updateOrderDetailModel.ProductId);

            if (orderDetail == null) {
                return false;
            }

            orderDetail.Quantity = updateOrderDetailModel.Quantity;

            _context.SaveChanges();
            return true;
        }

    }
}
