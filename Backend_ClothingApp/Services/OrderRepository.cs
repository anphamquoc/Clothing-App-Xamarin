using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;
        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }
        public OrderVM CreateOrder(AddOrderModel addOrderModel)
        {
            Order order = new Order
            {
                Address = addOrderModel.Address,
                Email = addOrderModel.Email,
                FullName = addOrderModel.FullName,
                PhoneNumber = addOrderModel.PhoneNumber,
                Total = addOrderModel.Total,
                UserId = addOrderModel.UserId,
                Status = addOrderModel.Status
            };

            _context.Add(order);
            _context.SaveChanges();

            return new OrderVM(order);
        }

        public bool DeleteOrder(DeleteOrderModel deleteOrderModel)
        {
            Order order = _context.Orders.SingleOrDefault(order => order.id == deleteOrderModel.OrderId);

            if(order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return true;
        }

        public List<OrderVM> GetAllOrderByUserId(string userId)
        {
            List<Order> orders = _context.Orders.Where(Order => Order.UserId.ToString() == userId).ToList();

            return orders.Select(order => new OrderVM(order)).ToList();
        }

        public List<OrderVM> GetAllOrders()
        {
            List<Order> orders = _context.Orders.ToList();

            return orders.Select(order => new OrderVM(order)).ToList();
        }

        public OrderVM GetOrderByOrderId(string orderId)
        {
            Order order = _context.Orders.SingleOrDefault(order => order.id.ToString() == orderId);
            if (order == null)
            {
                return null;
            }

            return new OrderVM(order);
        }

        public bool UpdateOrder(UpdateOrderModel updateOrderModel)
        {
            Order order = _context.Orders.SingleOrDefault(order => order.id == updateOrderModel.OrderId);

            if (order == null)
            {
                return false;
            }

            order.FullName = updateOrderModel.FullName;
            order.Email = updateOrderModel.Email;
            order.Address = updateOrderModel.Address;
            order.PhoneNumber = updateOrderModel.PhoneNumber;
            order.Total = updateOrderModel.Total;

            _context.SaveChanges();

            return true;
        }

        public bool UpdateOrderStatus(UpdateOrderStatusModel updateOrderStatusModel)
        {
            Order order = _context.Orders.SingleOrDefault(order => order.id == updateOrderStatusModel.OrderId);

            if (order == null)
            {
                return false;
            }

            order.Status = updateOrderStatusModel.Status;

            _context.SaveChanges();
            return true;
        }
    }
}
