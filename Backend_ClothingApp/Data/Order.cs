using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Data
{
    public class Order
    {
        [Key]
        public Guid id { get; set; }

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Tình trạng đơn hàng phải có")]
        public string Status { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
