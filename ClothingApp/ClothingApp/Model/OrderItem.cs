using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class OrderItem
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public OrderItem(string name, string date, int price, string status)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
            this.Status = status;
        }
    }
}
