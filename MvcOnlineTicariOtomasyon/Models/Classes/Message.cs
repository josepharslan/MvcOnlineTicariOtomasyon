using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Receiver { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Sender { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Subject { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string MessageContent { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MessageDate { get; set; }
    }
}