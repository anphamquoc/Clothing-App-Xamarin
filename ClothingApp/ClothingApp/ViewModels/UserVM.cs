using ClothingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class UserVM
    {
        public Guid id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
