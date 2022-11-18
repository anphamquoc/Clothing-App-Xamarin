using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.OrderModel
{
    public class AddOrderModel
    {
        [Required(ErrorMessage = "Tên phải có")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Địa chỉ phải có")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Tổng tiền phải có")]
        public long Total { get; set; }

        [Required(ErrorMessage = "Số điện thoại phải có")]
        [Phone(ErrorMessage = "Phải là số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email phải có")]
        [EmailAddress(ErrorMessage = "Phải là email")]
        public string Email { get; set; }

        public string Status { get; set; } = "Đang giao hàng";

        [Required]
        public Guid UserId { get; set; }
    }

    public class UpdateOrderModel
    {
        [Required(ErrorMessage = "Tên phải có")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Địa chỉ phải có")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Tổng tiền phải có")]
        public long Total { get; set; }

        [Required(ErrorMessage = "Số điện thoại phải có")]
        [Phone(ErrorMessage = "Phải là số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email phải có")]
        [EmailAddress(ErrorMessage = "Phải là email")]
        public string Email { get; set; }

        [Required]
        public Guid OrderId { get; set; }
    }

    public class UpdateOrderStatusModel
    {

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public string Status { get; set; }
    }

    public class DeleteOrderModel
    {

        [Required]
        public Guid OrderId { get; set; }
    }
}
