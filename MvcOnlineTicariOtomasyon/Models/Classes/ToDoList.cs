using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Value { get; set; }
        [Column(TypeName = "Bit")]
        public bool Status { get; set; }
    }
}