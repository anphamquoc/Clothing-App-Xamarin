using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly MyDbContext _context;
        public CartRepository(MyDbContext context)
        {
            _context = context;
        }
        public CartVM Create(AddCartModel addCartModel)
        {
            Cart Cart = _context.Carts.SingleOrDefault(cart => cart.UserId == addCartModel.UserId);

            if(Cart != null)
            {
                return null;
            }

            Cart = new Cart
            {
                UserId = addCartModel.UserId
            };

            _context.Carts.Add(Cart);
            _context.SaveChanges();

            return new CartVM(Cart);
        }

        public bool Delete(DeleteCartModel deleteCartModel)
        {
            Cart cart = _context.Carts.SingleOrDefault(cart => cart.UserId == deleteCartModel.UserId);

            if(cart == null)
            {
                return false;
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }

        public CartVM GetByUserId(string UserId)
        {
            Cart cart = _context.Carts.SingleOrDefault(cart => cart.UserId.ToString() == UserId);

            if(cart == null)
            {
                return null;
            }

            return new CartVM(cart);
        }
    }
}
