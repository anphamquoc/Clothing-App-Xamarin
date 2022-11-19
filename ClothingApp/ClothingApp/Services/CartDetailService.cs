using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    class CartDetailService : ICartDetailRepository
    {
        private readonly SendRequestAPI sendRequestAPI = new SendRequestAPI();
        async public Task<ApiResponse> AddProductToCart(AddToCartModel addToCartModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/CartDetail", addToCartModel);
            return await Task.FromResult(apiResponse);
        }

        async public Task<ApiResponse> DeleteProductFromCart(DeleteProductModel deleteProductModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.DeleteRequest("api/CartDetail", deleteProductModel);
            return await Task.FromResult(apiResponse);
        }

        async public Task<ApiResponse> GetAllProductByCartId(string cartId)
        {
            ApiResponse apiResponse = await sendRequestAPI.GetRequest($"api/CartDetail/{cartId}");
            return await Task.FromResult(apiResponse);
        }

        async public Task<ApiResponse> UpdateQuantityProductFromCart(UpdateProductQuantityModel updateProductQuantityModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PutRequest($"api/CartDetail", updateProductQuantityModel);
            return await Task.FromResult(apiResponse);
        }
    }
}
