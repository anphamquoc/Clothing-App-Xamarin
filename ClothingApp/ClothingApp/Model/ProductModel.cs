using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class AddProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string ImgUrl { get; set; }
    }

    public class UpdateProductModel: AddProductModel
    { 
    }
}
