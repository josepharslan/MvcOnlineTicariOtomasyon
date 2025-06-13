using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}