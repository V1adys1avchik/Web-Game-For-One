using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.BL.Game.Guid
{
    public interface IGuild
    {
        string Intro { get; set; }
        NPC NpcRole { get; set; }
        Item ItemType { get; set; }
        void MeetGuildMember(GameViewModel gameModel);
        double AmountOfMoneyForGuildMember { get; set; }
    }
}
