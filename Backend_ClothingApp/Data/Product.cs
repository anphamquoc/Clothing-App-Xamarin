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

        [Required]
        [MinLength(10, ErrorMessage = "Tên sản phẩm ít nhất phải có 10 kí tự")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Mô tả ít nhất phải có 10 kí tự")]
        public string Description { get; set; }

        [Required]
        public long Price { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
