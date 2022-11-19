using ClothingApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface ICartRepository
    {
        Task<ApiResponse> GetCartByUserId(string userId);
        Task<ApiResponse> CreateCart(string userId);
    }
}
