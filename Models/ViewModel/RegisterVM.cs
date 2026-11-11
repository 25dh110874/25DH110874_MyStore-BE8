using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _25DH110874_MyStore.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Số điện thoại")]
        public string CustomerPhone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}