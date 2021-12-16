using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.BL.Game.Bar
{
    public class MyBar
    {
        public static void GoBar(GameViewModel gameModel)
        {
            gameModel.AppearModel.Intro = "Baaaaar!!!";
            gameModel.AppearModel.NpcRole = NPC.Bar;
            gameModel.AppearModel.Item = "2$";
            gameModel.AppearModel.ItemType = Item.Beer;
        }
        public static bool BuyBeer(GameViewModel gameModel)
        {
            return gameModel.answerModel.Beer < 2 && gameModel.answerModel.PlayerMoney > 2;
        }
    }
}