﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.ViewModels
{
    public class OrderVM
    {
        public string id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public long Total { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderDetailVM> OrderDetails { get; set; }
    }
}
