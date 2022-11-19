using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class CreateOrderModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public long Total { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; } = "Đang giao hàng";
    }

    public class EditOrderModel : CreateOrderModel
    {
        public string OrderId { get; set; }
        public new string Status { get; set; }
    }

    public class UpdateStatusOrderModel
    {
        public string OrderId { get; set; }
        public string Status { get; set; }
    }

    public class DeleteOrderModel
    {
        public string OrderId { get; set; }
    }
}
