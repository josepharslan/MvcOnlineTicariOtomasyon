using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}