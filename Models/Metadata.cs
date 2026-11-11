using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _25DH110874_MyStore.Models
{
    
    public class CategoryMetadata
    {
        [HiddenInput]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string CategoryName { get; set; }
    }
    
    public class UserMetadata
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain letters and numbers")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}