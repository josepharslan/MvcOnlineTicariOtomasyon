using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoTrack
    {
        [Key]
        public int CargoTrackId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime TrackDate { get; set; }
    }
}