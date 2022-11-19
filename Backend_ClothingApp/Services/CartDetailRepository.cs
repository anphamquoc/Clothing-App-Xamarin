using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.CartDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class CartDetailRepository : ICartDetailRepository
    {
        private readonly MyDbContext _context;
        public CartDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        public CartDetailVM AddCartDetail(AddCartDetail addCartDetail)
        {
            CartDetail cartDetail = _context.CartDetails.SingleOrDefault(cartDetail => cartDetail.CartId == addCartDetail.CartId && cartDetail.ProductId == addCartDetail.ProductId);

            if(cartDetail != null)
            {
                return null;
            }
            cartDetail = new CartDetail
            {
                CartId = addCartDetail.CartId,
                ProductId = addCartDetail.ProductId,
                Quantity = addCartDetail.Quantity,
            };

            _context.CartDetails.Add(cartDetail);
            _context.SaveChanges();

            var e = _context.Entry(cartDetail);
            e.Reference(p => p.Product).Load();

            return new CartDetailVM(cartDetail);
        }


        public bool DeleteCartDetail(DeleteCartDetail deleteCartDetail)
        {
            CartDetail cartDetail = _context.CartDetails.SingleOrDefault(cartDetail => cartDetail.CartId == deleteCartDetail.CartId && cartDetail.ProductId == deleteCartDetail.ProductId);

            if(cartDetail == null)
            {
                return false;
            }

            _context.CartDetails.Remove(cartDetail);

            _context.SaveChanges();

            return true;
        }

        public List<CartDetailVM> GetAllCartDetailByCartId(string cartId)
        {
            List<CartDetail> cartDetails = _context.CartDetails.Where(cartDetail => cartDetail.CartId.ToString() == cartId).ToList();

            //var e = _context.Entry(cartDetails);
            //e.Reference(p => p.Select(e => e.Product)).Load();

            List<CartDetailVM> cartDetailVMs = cartDetails.Select(cartDetail => new CartDetailVM(cartDetail)).ToList();

            return cartDetailVMs;
        }

        public bool UpdateQuantity(UpdateCartDetail updateCartDetail)
        {

            CartDetail cartDetail = _context.CartDetails.SingleOrDefault(cartDetail => cartDetail.CartId == updateCartDetail.CartId && cartDetail.ProductId == updateCartDetail.ProductId);

            if(cartDetail == null)
            {
                return false;
            }

            cartDetail.Quantity = updateCartDetail.Quantity;

            _context.SaveChanges();

            return true;

        }
    }
}
