using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SaleTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd HH:mm ", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}