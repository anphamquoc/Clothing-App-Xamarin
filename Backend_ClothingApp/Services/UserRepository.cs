using Backend_ClothingApp.Data;
using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurePasswordHasher securePasswordHasher = new SecurePasswordHasher();
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public bool Delete(string id)
        {
            var user = _context.Users.SingleOrDefault(user => user.id.ToString() == id);

            if(user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public List<UserVM> GetAll()
        {
            var users = _context.Users.Select(user => new UserVM(user));

            return users.ToList();
        }

        public UserVM GetById(string id)
        {
            var user = _context.Users.SingleOrDefault(user => user.id.ToString() == id);
            if(user != null)
            {
                return new UserVM(user);
            }

            return null;
        }

        public UserVM Login(LoginModel loginModel)
        {
            var user = _context.Users.SingleOrDefault(user => user.Username == loginModel.Username);
            if(user == null)
            {
                return null;
            }

            bool check = securePasswordHasher.Verify(loginModel.Password, user.Password);
            if(!check)
            {
                return null;
            }

            return new UserVM(user);
        }

        public UserVM Register(RegisterModel registerModel)
        {
            var user = _context.Users.SingleOrDefault(user => user.Username == registerModel.Username);
            if(user != null)
            {
                return null;
            }

            string hashPassword = securePasswordHasher.Hash(registerModel.Password);

            user = new User
            {
                Username = registerModel.Username,
                Password = hashPassword
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return new UserVM(user);
        }

        public bool Update(string userId, UpdateUserModel updateUserModel)
        {
            var user = _context.Users.SingleOrDefault(user => user.id.ToString() == userId);
            if(user == null)
            {
                return false;
            }

            user.PhoneNumber = updateUserModel.PhoneNumber;
            user.Address = updateUserModel.Address;
            user.Email = updateUserModel.Email;
            user.FullName = updateUserModel.FullName;

            _context.SaveChanges();

            return true;
        }

        public bool ChangePassword(string userId, ChangePasswordUserModel changePasswordUserModel)
        {
            var user = _context.Users.SingleOrDefault(user => user.id.ToString() == userId);
            if (user == null)
            {
                return false;
            }

            if (!securePasswordHasher.Verify(changePasswordUserModel.Password, user.Password))
            {
                return false;
            }

            user.Password = securePasswordHasher.Hash(changePasswordUserModel.NewPassword);

            _context.SaveChanges();
            return true;
        }
    }
}
