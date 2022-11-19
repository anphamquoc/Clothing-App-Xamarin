using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.CartDetailModel
{
    public class CartDetailVM
    {
        public ProductVM Product { get; set; }
        public int Quantity { get; set; }

        public CartDetailVM(CartDetail cartDetail)
        {
            this.Product = new ProductVM(cartDetail.Product);
            this.Quantity = cartDetail.Quantity;
        }
    }
}
