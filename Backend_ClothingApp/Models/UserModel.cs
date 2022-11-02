using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models
{
    public class LoginModel
    {

        [Required]
        [MinLength(6, ErrorMessage = "Tên người dùng phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Tên người dùng có nhiều nhất 32 kí tự")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Mật khẩu có nhiều nhất 32 kí tự")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])[a-zA-Z0-9]{6,32}$", ErrorMessage = "Mật khẩu phải có một kí tự thường, một số và một kí tự hoa")]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "Tên người dùng phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Tên người dùng có nhiều nhất 32 kí tự")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        [MaxLength(32, ErrorMessage = "Mật khẩu có nhiều nhất 32 kí tự")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])[a-zA-Z0-9]{6,15}$", ErrorMessage = "Mật khẩu phải có một kí tự thường, một số và một kí tự hoa")]
        public string Password { get; set; }
    }

    public class UpdateUserModel
    {
        [Required]
        public string Address { get; set; }

        [Required]
        [Phone(ErrorMessage = "Phải là số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Phải là email")]
        public string Email { get; set; }
    }
}
