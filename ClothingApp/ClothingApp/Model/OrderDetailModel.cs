using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class AddProductToOrderModel
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }

    public class UpdateQuantityOrderModel : AddProductModel
    {

    }

    public class DeleteOrderDetailModel{
        public string OrderId { get; set; }
        public string ProductId { get; set; }
    }
}
