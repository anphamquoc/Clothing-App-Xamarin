using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.ProductModel
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Tên phải có")]
        [MinLength(10, ErrorMessage = "Tên sản phẩm ít nhất phải có 10 kí tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mô tả phải có")]
        [MinLength(10, ErrorMessage = "Mô tả ít nhất phải có 10 kí tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá cả phải có")]
        public long Price { get; set; }

        [Required(ErrorMessage ="Hình ảnh phải có")]
        public string ImgUrl { get; set; }
    }

    public class UpdateProductModel: AddProductModel
    {

    }
}
