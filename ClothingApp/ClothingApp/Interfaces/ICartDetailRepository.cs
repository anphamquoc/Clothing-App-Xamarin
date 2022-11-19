using ClothingApp.Helpers;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface ICartDetailRepository
    {
        Task<ApiResponse> GetAllProductByCartId(string cartId);
        Task<ApiResponse> AddProductToCart(AddToCartModel addToCartModel);
        Task<ApiResponse> UpdateQuantityProductFromCart(UpdateProductQuantityModel updateProductQuantityModel);
        Task<ApiResponse> DeleteProductFromCart(DeleteProductModel deleteProductModel);
    }
}
