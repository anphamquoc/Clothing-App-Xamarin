using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    class UserItem
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public UserItem(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
