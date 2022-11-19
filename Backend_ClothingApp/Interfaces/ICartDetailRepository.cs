using Backend_ClothingApp.Models.CartDetailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface ICartDetailRepository
    {
        List<CartDetailVM> GetAllCartDetailByCartId(string cartId);
        bool DeleteCartDetail(DeleteCartDetail deleteCartDetail);
        bool UpdateQuantity(UpdateCartDetail updateCartDetail);
        CartDetailVM AddCartDetail(AddCartDetail addCartDetail);
    }
}
