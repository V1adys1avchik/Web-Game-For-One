using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.BL.NPCsType;

namespace Web_Ankh_Mork.Models
{
    public class AppearModel
    {
        public string Intro { get; set; }
        public NPC NpcRole { get; set; }
        public Item ItemType { get; set; }
        public string Item { get; set; }
        public double MinMoney { get; set; }
    }
}