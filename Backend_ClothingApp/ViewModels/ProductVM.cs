using Backend_ClothingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.ProductModel
{
    public class ProductVM
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string ImgUrl { get; set; }

        public ProductVM(Product product)
        {
            this.id = product.id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.ImgUrl = product.ImgUrl;
        }
    }
}
