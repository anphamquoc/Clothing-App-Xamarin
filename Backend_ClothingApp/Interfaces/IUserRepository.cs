using Backend_ClothingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface IUserRepository
    {
        List<UserVM> GetAll();
        UserVM GetById(string id);
        UserVM Register(RegisterModel registerModel);
        UserVM Login(LoginModel loginModel);
        bool Update(string userId, UpdateUserModel updateUserModel);
        bool ChangePassword(string userId, ChangePasswordUserModel changePasswordUserModel);
        bool Delete(string id);
    }
}
