using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Web_Ankh_Mork.Models
{
    public class AnswerModel
    {
        [Range(1,100)]
        public double Money { get; set; }
        public double PlayerMoney { get; set; }
        public int Beer { get; set; }
        public bool Alive { get; set; }
    }
}