using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _25DH110874_MyStore.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

    }
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class PartialClass
    {
    }
}