using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Data
{
    public class OrderDetail
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Số lượng phải có")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 1")]
        public int Quantity { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
