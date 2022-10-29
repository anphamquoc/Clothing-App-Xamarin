using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Model
{
    public class HomeItem
    {
        public string ImgUrl { get; set; }
        public string Name { get; set; }

        public HomeItem(string imgUrl, string name)
        {
            this.ImgUrl = imgUrl;
            this.Name = name;
        }
    }
}
