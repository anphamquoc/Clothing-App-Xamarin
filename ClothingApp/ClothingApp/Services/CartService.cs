using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    class CartService : ICartRepository
    {
        private readonly SendRequestAPI sendRequestAPI = new SendRequestAPI();
        async public Task<ApiResponse> CreateCart(string userId)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/Cart", new
            {
                UserId = userId
            });

            return await Task.FromResult(apiResponse);
        }

        async public Task<ApiResponse> GetCartByUserId(string userId)
        {
            ApiResponse apiResponse = await sendRequestAPI.GetRequest($"api/Cart/{userId}");

            return await Task.FromResult(apiResponse);
        }
    }
}
