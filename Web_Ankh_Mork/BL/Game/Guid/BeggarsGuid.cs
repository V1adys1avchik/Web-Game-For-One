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
    public class BeggarsGuid : IGuild
    {
        public double AmountOfMoneyForGuildMember { get; set; }
        public string Intro { get; set; } = "";
        public NPC NpcRole { get; set; } = NPC.Beggar;
        public Item ItemType { get; set; }

        public void MeetGuildMember(GameViewModel gameModel)
        {
            UpdateMembersStatus(gameModel);
        }

        private void UpdateMembersStatus(GameViewModel gameModel)
        {
            using (AnkhMorokContext context = new AnkhMorokContext())
            {
                var beggar = context.Beggars.OrderBy(r => System.Guid.NewGuid()).Skip(0).Take(1).FirstOrDefault();

                gameModel.AppearModel.ItemType = beggar.AmountOfMoney == 0 ? Item.Beer : Item.Money;
                gameModel.AppearModel.Item = beggar.AmountOfMoney == 0 ? Item.Beer.ToString() : beggar.AmountOfMoney.ToString();
                gameModel.AppearModel.NpcRole = NpcRole;
                gameModel.AppearModel.Intro = $"{Intro} {beggar.Name} he is {beggar.BeggarType}. (Replic: {beggar.Replic})";
                gameModel.AppearModel.MinMoney = beggar.AmountOfMoney;

                gameModel.answerModel.Money = beggar.AmountOfMoney;
            }
        }
    }
}