using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Ankh_Mork.DB.Entity
{
    public class Thief
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Fee { get; set; }
    }
}