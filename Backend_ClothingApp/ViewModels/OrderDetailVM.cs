using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.OrderDetailModel
{
    public class OrderDetailVM
    {
        public int Quantity { get; set; }
        public ProductVM Product { get; set; }

        public OrderDetailVM(OrderDetail orderDetail)
        {
            Quantity = orderDetail.Quantity;
            Product = new ProductVM(orderDetail.Product);
        }
    }
}
