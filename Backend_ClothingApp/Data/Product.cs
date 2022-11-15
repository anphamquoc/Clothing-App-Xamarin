using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]   
        public Guid id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm phải có")]
        [MinLength(10, ErrorMessage = "Tên sản phẩm ít nhất phải có 10 kí tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mô tả sản phẩm phải có")]
        [MinLength(10, ErrorMessage = "Mô tả ít nhất phải có 10 kí tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hình ảnh phải có")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Giá cả phải có")]
        public long Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }

    }
}
