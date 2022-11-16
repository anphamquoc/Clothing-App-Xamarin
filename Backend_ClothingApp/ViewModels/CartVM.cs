using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.CartDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.CartModel
{
    public class CartVM
    {
        public Guid id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
        public ICollection<CartDetailVM> CartDetails { get; set; }

        public CartVM(Cart cart)
        {
            this.id = cart.id;
            this.CreatedAt = cart.CreatedAt;
            this.UserId = cart.UserId;
            this.CartDetails = cart.CartDetails.Select(cartDetail => new CartDetailVM(cartDetail)).ToList();
        }
    }
}
