using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Tên người dùng phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Tên người dùng có nhiều nhất 32 kí tự")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Mật khẩu có nhiều nhất 32 kí tự")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])[a-zA-Z0-9]{6,15}$", ErrorMessage = "Mật khẩu phải có một kí tự thường, một số và một kí tự hoa")]
        public string Password { get; set; }

        [RegularExpression("admin|user")]
        public string Role { get; set; } = "user";

        public string Address { get; set; }

        [Phone(ErrorMessage = "Phải là số điện thoại")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Phải là email")]
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
