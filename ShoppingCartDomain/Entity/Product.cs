using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingCartDomain.Entity
{
    public class Product
    {
        [HiddenInput(DisplayValue = true)]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "wao")]
        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}