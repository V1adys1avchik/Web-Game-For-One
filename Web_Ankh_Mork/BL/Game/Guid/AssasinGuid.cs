using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.UI;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.DB;
using Web_Ankh_Mork.DB.Entity;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.BL.Game.Guid
{
    public class AssasinGuid : IGuild
    {
        public double AmountOfMoneyForGuildMember { get; set; }
        public string Intro { get; set; } = "";
        public NPC NpcRole { get; set; } = NPC.Assasin;
        public Item ItemType { get; set; } = Item.Money;

        public void MeetGuildMember(GameViewModel gameModel)
        {
            UpdateMembersStatus(gameModel);
        }

        private void UpdateMembersStatus(GameViewModel gameModel)
        {
            using (AnkhMorokContext context = new AnkhMorokContext())
            {
                var assasins = context.Assasins.OrderBy(r => System.Guid.NewGuid()).ToList();

                var assasin = context.Assasins.Where(a => a.IsOcupied != false).OrderBy(r => System.Guid.NewGuid())
                    .Skip(0).Take(1).FirstOrDefault();

                gameModel.AppearModel.Item = GetAvrgCost(assasins).ToString();
                gameModel.AppearModel.NpcRole = NpcRole;
                gameModel.AppearModel.ItemType = ItemType;
                gameModel.AppearModel.Intro = $"{Intro} {assasin.Name} he's max reward: {assasin.HighestReward}";
                gameModel.AppearModel.MinMoney = assasin.LowestReward;
            }
        }

        private double GetAvrgCost(List<Assasin> assasins)
        {
            return Math.Round(assasins.Select(x => x.HighestReward - x.LowestReward).Average());
        }
    }
}