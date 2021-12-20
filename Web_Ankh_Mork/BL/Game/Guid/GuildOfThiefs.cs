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
    public class GuildOfThiefs : IGuild
    {
        public static int thefts = 6;
        public static void ResetThefts()
        {
            thefts = 6;
        }
        public double AmountOfMoneyForGuildMember { get; set; }
        public string Intro { get; set; } = "";
        public NPC NpcRole { get; set; } = NPC.Thief;
        public Item ItemType { get; set; } = Item.Money;

        public void MeetGuildMember(GameViewModel gameModel)
        {
            thefts--;
            UpdateMembersStatus(gameModel);
        }

        private void UpdateMembersStatus(GameViewModel gameModel)
        {
            using (AnkhMorokContext context = new AnkhMorokContext())
            {
                var thief = context.Thiefs.FirstOrDefault();
                
                gameModel.AppearModel.Item = thief.Fee.ToString();
                gameModel.AppearModel.NpcRole = NpcRole;
                gameModel.AppearModel.ItemType = ItemType;
                gameModel.AppearModel.Intro = $"{Intro} {thief.Name} he is {NpcRole}";
                gameModel.AppearModel.MinMoney = thief.Fee;

                gameModel.answerModel.Money = thief.Fee;
            }
        }
    }
}