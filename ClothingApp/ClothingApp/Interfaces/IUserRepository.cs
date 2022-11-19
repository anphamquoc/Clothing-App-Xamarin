using ClothingApp.Helpers;
using ClothingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    public interface IUserRepository
    {
        Task<ApiResponse> Login(UserLoginModel userLoginModel);
        Task<ApiResponse> Register(UserRegisterModel userRegisterModel);
        Task<ApiResponse> GetUserById(string userId);
        Task<ApiResponse> GetAllUsers();
        Task<ApiResponse> UpdateUser(string userId, UpdateUserModel updateUserModel);
        Task<ApiResponse> DeleteUser(string userId);
        Task<ApiResponse> ChangeUserPassword(string userId, ChangeUserPasswordModel changeUserPasswordModel);
    }
}
