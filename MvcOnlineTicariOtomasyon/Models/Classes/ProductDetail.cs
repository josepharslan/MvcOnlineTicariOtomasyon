using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetail
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Detail> Details { get; set; }
    }
}