using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend_ClothingApp.Data
{
    public class CartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Giá trị của số lượng phải lớn hơn 1")]
        public int Quantity { get; set; }

        [Required]
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
