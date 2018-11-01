using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models
{
    public class Product
    {

        private string name;
        public int ProductId { get; set; }

        //public string Name
        //{
        //    get => ProductId + name;
        //    set => name = value;
        //}

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}