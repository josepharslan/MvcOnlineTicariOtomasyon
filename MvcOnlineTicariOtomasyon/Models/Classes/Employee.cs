using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "Varchar")]
        public string EmployeeImage { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}