using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.ViewModels
{
    public class CartVM
    {
        public string id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CartDetailVM> CartDetails { get; set; }
    }
}
