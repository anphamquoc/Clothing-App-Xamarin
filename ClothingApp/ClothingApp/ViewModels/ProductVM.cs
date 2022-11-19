using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.ViewModels
{
    public class ProductVM
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string ImgUrl { get; set; }

        public ProductVM(string id, string name, string description, long price, string imgUrl)
        {
            this.id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.ImgUrl = imgUrl;
        }
    }
}
