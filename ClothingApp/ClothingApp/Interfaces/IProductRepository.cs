using ClothingApp.Helpers;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface IProductRepository
    {
        Task<ApiResponse> GetAllProducts();
        Task<ApiResponse> GetProductById(string productId);
        Task<ApiResponse> AddNewProduct(AddProductModel addProductModel);
        Task<ApiResponse> UpdateProduct(string productId, UpdateProductModel updateProductModel);
        Task<ApiResponse> DeleteProduct(string productId);
    }
}
