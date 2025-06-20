﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "30 karakterden fazla giriş yapılamaz")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}