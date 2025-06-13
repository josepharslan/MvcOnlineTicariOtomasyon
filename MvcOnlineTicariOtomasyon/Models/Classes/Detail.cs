using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }
        public string ProductName { get; set; }
        public string ProductInfo { get; set; }
    }
}