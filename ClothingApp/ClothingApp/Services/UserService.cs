using ClothingApp.Helpers;
using ClothingApp.Interfaces;
using ClothingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Services
{
    class UserService: IUserRepository
    {
        private readonly HttpClient httpClient;
        private readonly SendRequestAPI sendRequestAPI;
        public UserService()
        {
            httpClient = new HttpClient();
            sendRequestAPI = new SendRequestAPI();
        }

        public async Task<ApiResponse> GetAllUsers()
        {
            ApiResponse apiResponse = await sendRequestAPI.GetRequest("api/User");
            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse> GetUserById(string userId)
        {
            ApiResponse apiResponse = await sendRequestAPI.GetRequest($"api/User/{userId}");
            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse> Login(UserLoginModel userLoginModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/User/Login", userLoginModel);
            return await Task.FromResult(apiResponse);

        }

        public async Task<ApiResponse> Register(UserRegisterModel userRegisterModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PostRequest("api/User/Register", userRegisterModel);
            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse> UpdateUser(string userId, UpdateUserModel updateUserModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PutRequest($"api/User/{userId}", updateUserModel);

            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse> DeleteUser(string userId)
        {
            ApiResponse apiResponse = await sendRequestAPI.DeleteRequest($"api/User/{userId}", new { });
            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse> ChangeUserPassword(string userId, ChangeUserPasswordModel changeUserPasswordModel)
        {
            ApiResponse apiResponse = await sendRequestAPI.PutRequest($"api/User/ChangePassword/{userId}", changeUserPasswordModel);
            return await Task.FromResult(apiResponse);
        }
    }
}
