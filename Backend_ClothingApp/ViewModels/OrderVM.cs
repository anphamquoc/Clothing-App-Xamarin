using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.OrderDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.OrderModel
{
    public class OrderVM
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public long Total { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderDetailVM> OrderDetails { get; set; }

        public OrderVM(Order order)
        {
            id = order.id;
            FullName = order.FullName;
            Address = order.Address;
            Total = order.Total;
            PhoneNumber = order.PhoneNumber;
            Email = order.Email;
            CreatedAt = order.CreatedAt;
            Status = order.Status;
            OrderDetails = order.OrderDetails.Select(orderDetail => new OrderDetailVM(orderDetail)).ToList();
        }
    }
}
