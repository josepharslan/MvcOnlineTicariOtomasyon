using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Ad en fazla 30 karakter olabilir")]
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CustomerCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }
        public bool Status { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}