using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterModel: UserLoginModel
    {
    }

    public class UpdateUserModel
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }

    public class ChangeUserPasswordModel
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}

