using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Web_Ankh_Mork.BL.Game.Bar;
using Web_Ankh_Mork.BL.Game.Core;
using Web_Ankh_Mork.BL.Game.Guid;
using Web_Ankh_Mork.BL.Items;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.BL.Game
{
    public class Game
    {
        private  IGuild guild;
        public  GameViewModel ContinueGame(GameViewModel model)
        {
            Processed(model);

            return model;
        }

        public  GameViewModel Skip(GameViewModel model)
        {
            Processed(model);

            return model;
        }
        public  GameViewModel Accept(GameViewModel model)
        {

            if (!model.answerModel.Alive)
            {
                return model;
            }

            Processed(model);

            return model;
        }

        private  void Processed(GameViewModel model)
        {
            guild = Place.GetRandomPlace();
            if (guild == null)
            {
                MyBar.GoBar(model);
            }
            else
            {
                guild.MeetGuildMember(model);
            }
        }

        public  void ResultOfChoise(GameViewModel model)
        {
            if (MyBar.BuyBeer(model) && model.AppearModel.NpcRole == NPC.Bar)
            {
                model.answerModel.PlayerMoney -= 2;
                model.answerModel.Beer++;
            }

            if (model.AppearModel.NpcRole == NPC.Assasin || model.AppearModel.NpcRole == NPC.Thief
                                                         || model.AppearModel.NpcRole == NPC.Beggar)
            {
                if (model.AppearModel.ItemType == Item.Beer && model.answerModel.Beer > 0 && model.AppearModel.NpcRole == NPC.Beggar)
                {
                    model.answerModel.Beer--;
                }
                else if(model.answerModel.Beer == 0 && model.AppearModel.ItemType == Item.Beer && model.AppearModel.NpcRole == NPC.Beggar)
                {
                    model.answerModel.Alive = false;
                }

                if (model.AppearModel.NpcRole == NPC.Assasin && model.AppearModel.MinMoney > model.answerModel.Money)
                {
                    model.answerModel.Alive = false;
                }
                if (model.AppearModel.ItemType == Item.Money)
                {
                    model.answerModel.PlayerMoney -= model.answerModel.Money;
                }

                if (model.answerModel.PlayerMoney <= 0)
                {
                    model.answerModel.Alive = false;
                }

                Math.Round(model.answerModel.PlayerMoney);
            }
            else if(model.AppearModel.NpcRole == NPC.Fool)
            {
                model.answerModel.PlayerMoney += model.answerModel.Money;
                Math.Round(model.answerModel.PlayerMoney);
            }
        }
    }
}