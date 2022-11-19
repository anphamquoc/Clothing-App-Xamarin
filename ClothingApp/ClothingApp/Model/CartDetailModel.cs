using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class AddToCartModel
    {
        public string CartId { get; set; }
        public string ProductId { get; set; }
    }

    public class UpdateProductQuantityModel: AddToCartModel { 
        public int Quantity { get; set; }
    }

    public class DeleteProductModel : AddToCartModel { }
}
