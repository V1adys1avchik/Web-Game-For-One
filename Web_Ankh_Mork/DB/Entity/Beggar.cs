using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Ankh_Mork.DB.Entity
{
    public class Beggar
    {
        public int ID { get; set; }
        [Required]
        public string BeggarType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double AmountOfMoney { get; set; }
        public string Replic { get; set; }

    }
}