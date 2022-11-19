using Backend_ClothingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models
{
    public class UserVM
    {
        public Guid id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserVM(User user)
        {
            Address = user.Address;
            CreatedAt = user.CreatedAt;
            Email = user.Email;
            id = user.id;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
            FullName = user.FullName;
            Username = user.Username;
            UpdatedAt = user.UpdatedAt;
        }
    }
}
