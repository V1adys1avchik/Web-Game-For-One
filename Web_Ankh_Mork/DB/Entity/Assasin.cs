using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Ankh_Mork.DB.Entity
{
    public class Assasin
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int HighestReward { get; set; }
        [Required]
        public int LowestReward { get; set; }
        [Required]
        public bool IsOcupied { get; set; }
    }
}