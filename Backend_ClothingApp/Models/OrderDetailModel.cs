using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.OrderDetailModel
{
    public class AddOrderDetailModel
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public int Quantity { get; set; } = 1;
    }

    public class UpdateOrderDetailModel
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 1")]
        public int Quantity { get; set; }
    }

    public class DeleteOrderDetailModel
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
