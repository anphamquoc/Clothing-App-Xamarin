using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.CartDetailModel
{
    public class AddCartDetail
    {
        public int Quantity = 1;

        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }

    public class UpdateCartDetail
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Giá trị của số lượng phải lớn hơn 1")]
        public int Quantity { get; set; }
    }

    public class DeleteCartDetail
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
