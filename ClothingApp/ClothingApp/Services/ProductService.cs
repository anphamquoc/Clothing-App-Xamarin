using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    class ProductService : IProductRepository
    {
        private readonly SendRequestAPI sendRequestAPI = new SendRequestAPI();
        async public Task<ApiResponse> AddNewProduct(AddProductModel addProductModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/Product", addProductModel);
            return await Task.FromResult(apiResponse);
        }

        async public Task<ApiResponse> DeleteProduct(string productId)
        {
            return await sendRequestAPI.DeleteRequest($"api/Product/{productId}", new { });   
        }

        async public Task<ApiResponse> GetAllProducts()
        {
            return await sendRequestAPI.GetRequest("api/Product");
        }

        async public Task<ApiResponse> GetProductById(string productId)
        {
            return await sendRequestAPI.GetRequest($"api/Product/{productId}");    
        }

        async public Task<ApiResponse> UpdateProduct(string productId, UpdateProductModel updateProductModel)
        {
            return await sendRequestAPI.PutRequest($"api/Product/{productId}", updateProductModel);    
        }
    }
}
