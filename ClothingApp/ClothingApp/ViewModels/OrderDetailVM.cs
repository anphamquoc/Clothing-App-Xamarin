using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.ViewModels
{
    public class OrderDetailVM
    {
        public int Quantity { get; set; }
        public ProductVM Product { get; set; }

        public OrderDetailVM OrderDetail { get { return this; } }
    }
}
