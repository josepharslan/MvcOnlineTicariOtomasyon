using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Class4
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<InvoiceDetail> InvoicesDetails { get; set; }
    }
}