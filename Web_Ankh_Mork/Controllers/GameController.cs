using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ankh_Mork.BL.Game;
using Web_Ankh_Mork.BL.Game.Guid;
using Web_Ankh_Mork.BL.NPCsType;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.Controllers
{
    public class GameController : Controller
    {
        private static GameViewModel _gameModel; // играть будет только 1-н )

        // GET: Game
        public ActionResult Start()
        {
            _gameModel = new GameViewModel();
            _gameModel.AppearModel = new AppearModel();
            _gameModel.answerModel = new AnswerModel();
            _gameModel.answerModel.Alive = true;
            _gameModel.answerModel.PlayerMoney = 100;
            Game.ContinueGame(_gameModel);


                return View("Starts",_gameModel);
        }

        public ActionResult Starts()
        {
            return View(_gameModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Acceptp(GameViewModel gameModel)
        {
            Game.ResultOfChoise(gameModel);
            if (gameModel.answerModel.Alive)
            {
                Game.Accept(gameModel);
                _gameModel = gameModel;
                return RedirectToAction("Starts");
            }
            
            GuildOfThiefs.ResetThefts();
            return View("End", gameModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Skip(GameViewModel gameModel)
        {
            if (gameModel.AppearModel.NpcRole == NPC.Assasin
                || gameModel.AppearModel.NpcRole == NPC.Beggar
                || gameModel.AppearModel.NpcRole == NPC.Thief)
            {
                GuildOfThiefs.ResetThefts();
                return View("End", gameModel);
            }

            Game.Skip(gameModel);
            if (gameModel.answerModel.Alive)
            {
                _gameModel = gameModel;
                return RedirectToAction("Starts");
            }

            GuildOfThiefs.ResetThefts();
            return View("End", gameModel);
        }

    }
}
