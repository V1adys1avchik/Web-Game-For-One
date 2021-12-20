using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.DB;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.BL.Game.Guid
{
    public class GuildOfFools : IGuild
    {
        public double AmountOfMoneyForGuildMember { get; set; }
        public string Intro { get; set; } = "";
        public NPC NpcRole { get; set; } = NPC.Fool;
        public Item ItemType { get; set; } = Item.Money;

        public void MeetGuildMember(GameViewModel gameModel)
        {
            UpdateMembersStatus(gameModel);
        }

        private void UpdateMembersStatus(GameViewModel gameModel)
        {
            using (AnkhMorokContext context = new AnkhMorokContext())
            {
                var fool = context.Fools.OrderBy(r => System.Guid.NewGuid()).Skip(0).Take(1).FirstOrDefault();

                gameModel.AppearModel.Item = fool.Salary.ToString();
                gameModel.AppearModel.NpcRole = NpcRole;
                gameModel.AppearModel.ItemType = ItemType;
                gameModel.AppearModel.Intro = $"{Intro} {fool.Name} he is {fool.FoolType}. (Replic: {fool.Replic})";

                gameModel.answerModel.Money = fool.Salary;
            }
        }
    }
}