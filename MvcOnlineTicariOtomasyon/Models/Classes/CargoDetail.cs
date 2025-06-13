﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Employee { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Receiver { get; set; }
        public DateTime CargoDate { get; set; }
    }
}